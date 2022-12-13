from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Subasta
from .serializers import SubastaSerializer,SubastaHistoricoSerializer
from rest_framework import viewsets
from .algoritmo import rechazar_restantes
import json
import cx_Oracle
import datetime

# Create your views here.
def agregar_subasta(monto_subasta,id_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_subasta = datetime.date.today()
    estado_fila = '1'
    estado_subasta = 'Postulada'
    cursor.callproc('SUBASTA_AGREGAR',[monto_subasta,id_venta,id_usuario,fecha_subasta,estado_fila,estado_subasta,salida])
    return round(salida.getvalue())

def modificar_subasta(id_subasta,monto_subasta,id_venta,id_usuario,estado_subasta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_subasta = datetime.date.today()
    cursor.callproc('SUBASTA_MODIFICAR',[id_subasta,monto_subasta,id_venta,fecha_subasta,id_usuario,estado_subasta,salida])
    return round(salida.getvalue())

def eliminar_subasta(id_subasta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SUBASTA_ELIMINAR',[id_subasta,salida])
    return round(salida.getvalue())

def aceptar_subasta(id_subasta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SUBASTA_ACEPTAR',[id_subasta,salida])
    return round(salida.getvalue())

def lista_subasta():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('SUBASTA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

def subasta_carga_venta(id_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('subasta_carga_venta', [id_venta,out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    lista_json=[]
    cont=0
    for dato in lista:
        fila=lista[cont]
        if fila[8] =='1':
            carga='Si'
        else:
            carga='No'
        fecha = str(fila[3])
        jd = {'id_venta':fila[2],
        'id_subasta':fila[0],
        'monto_subasta':fila[1],
        'fecha_subasta':fecha[:-9],
        'id_carga':fila[6],
        'capacidad_carga':fila[7],
        'tamano_carga':fila[9],
        'refrigeracion_carga':carga,}
        lista_json.append(jd)
        cont=cont+1
    return lista_json

def subasta_venta_user(id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('SUBASTA_VENTA', [id_usuario,out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)

    lista_json=[]
    cont=0
    for dato in lista:
        fila=lista[cont]
        fecha = str(fila[2])
        jd = {'id_subasta':fila[0],
        'monto_subasta':fila[1],
        'fecha_subasta':fecha[:-9],
        'id_venta':fila[3],
        'descripcion_venta':fila[4],
        'estado_venta':fila[5],}
        lista_json.append(jd)
        cont=cont+1
    return lista_json

def subasta_aceptada(id_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('SUBASTA_ACEPTADA', [id_venta,out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)

    lista_json=[]
    cont=0
    for dato in lista:
        fila=lista[cont]
        fecha = str(fila[2])
        jd = {'id_subasta':fila[0],
        'monto_subasta':fila[1],
        'fecha_subasta':fecha[:-9],
        'estado_subasta':fila[3],}
        lista_json.append(jd)
        cont=cont+1
    return jd

def subasta_carga():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('subasta_carga', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    lista_json=[]
    cont=0
    for dato in lista:
        fila=lista[cont]
        if fila[8] =='1':
            carga='Si'
        else:
            carga='No'
        fecha = str(fila[3])
        jd = {'id_subasta':fila[0],
        'monto_subasta':fila[1],
        'id_venta':fila[2],
        'fecha_subasta':fecha[:-9],
        'id_usuario':fila[4],
        'estado_subasta':fila[5],
        'id_carga':fila[6],
        'capacidad_carga':fila[7],
        'refrigeracion_carga':carga,
        'tamano_carga':fila[9]}
        lista_json.append(jd)
        cont=cont+1
    return lista_json
    

class SubastaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_subasta=0):
        if(id_subasta > 0):
            subastas=list(Subasta.objects.filter(id_subasta=id_subasta).values())
            if len(subastas) > 0:
                subasta = subastas[0]
                datos={"subasta":subasta}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: subasta No Encontrada"}
                return JsonResponse(datos, status=404)
        else:
            subastas = list(Subasta.objects.values())
            if len(subastas) > 0:
                datos={'message':"Success","subasta":subastas}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: subastas de venta No encontradas"}
                return JsonResponse(datos, status=404)
            

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_subasta(monto_subasta=jd['monto_subasta'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
                if salida == 0:
                    datos = {'message':'ERORR: no fue posible agregar la subasta'}
                    return JsonResponse(datos, status=500)
                else:
                    datos = {'message':'Success','id_subasta':salida}
                    return JsonResponse(datos, status=201)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=500)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)


    def put(self, request,id_subasta):
        try:
            jd = json.loads(request.body)
            subasteas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
            if len(subasteas) > 0:
                try:
                    salida = modificar_subasta(id_subasta=jd['id_subasta'],monto_subasta=jd['monto_subasta'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'],estado_subasta=jd['estado_subasta'])
                    if salida == 0:
                        datos = {'message':'ERORR: no fue posible modificar la subasta'}
                        return JsonResponse(datos, status=404)
                    else:
                        datos = {'message':'Success'}
                        return JsonResponse(datos, status=201)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: No se encuentra la subasta"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def delete(self, request,id_subasta):
        subastas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
        if len(subastas) > 0:
            try:
                salida = eliminar_subasta(id_subasta)
                if salida == 1:
                    datos={'message':"Success"}
                    return JsonResponse(datos, status=200)
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible eliminar la subasta'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=500)
        else:
            datos={'message':"ERROR: no se encuentra la subasta"}
            return JsonResponse(datos, status=404)

class SubastaVentaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self, request, id_venta):
        subastas=list(Subasta.objects.filter(id_venta=id_venta).values())
        if len(subastas) > 0:
            datos=subastas
            return JsonResponse(datos, status=200,safe=False)
        else:
            datos={'message':"ERROR: subasta No Encontrada"}
            return JsonResponse(datos, status=404)
    
class SubastaVentaUserView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self, request, id_usuario):
        try:
            salida = subasta_venta_user(id_usuario)
            return JsonResponse(salida,status=200,safe=False)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=500)

class SubastaCargaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request,id_venta):
        subastas = subasta_carga_venta(id_venta)
        if len(subastas) > 0:
            return JsonResponse(subastas,safe=False,status=200)
        else:
            datos={'message':"ERROR: subastas de venta No encontradas"}
            return JsonResponse(datos, status=404)

class SubastaAceptarView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request):
        subastas = subasta_carga()
        if len(subastas) > 0:
            return JsonResponse(subastas,safe=False,status=200)
        else:
            datos={'message':"ERROR: subastas de venta No encontradas"}
            return JsonResponse(datos, status=404)
    
    def put(self, request,id_subasta):
        try:
            subastas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
            if len(subastas) > 0:
                try:
                    salida = aceptar_subasta(id_subasta)
                    rechazar_restantes(id_subasta)
                    if salida == 0:
                        datos = {'message':'ERORR: no fue posible aceptar la subasta'}
                        return JsonResponse(datos, status=404)
                    else:
                        subasta=subastas[0]
                        return JsonResponse(subasta, status=201,safe=False)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: No se encuentra la subasta"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: tenemos problemas en estos momentos'}
            return JsonResponse(datos, status=500)    

class SubastaAceptada(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self, request, id_venta):
        try:
            salida = subasta_aceptada(id_venta)
            return JsonResponse(salida,status=200,safe=False)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=500)

class SubastaViewset(viewsets.ModelViewSet):
    queryset = Subasta.objects.filter(estado_fila='1')
    serializer_class = SubastaSerializer


class SubastaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Subasta.objects.all()
    serializer_class = SubastaHistoricoSerializer