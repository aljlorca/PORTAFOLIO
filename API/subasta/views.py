from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Subasta
from .serializers import SubastaSerializer,SubastaHistoricoSerializer
from rest_framework import viewsets
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
    cursor.callproc('SUBASTA_AGREGAR',[monto_subasta,id_venta,id_usuario,fecha_subasta,estado_fila,salida])
    return round(salida.getvalue())

def modificar_subasta(id_subasta,monto_subasta,id_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_subasta = datetime.date.today()
    cursor.callproc('SUBASTA_MODIFICAR',[id_subasta,monto_subasta,id_venta,fecha_subasta,id_usuario,salida])
    return round(salida.getvalue())

def eliminar_subasta(id_subasta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SUBASTA_ELIMINAR',[id_subasta,salida])
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
            else:
                datos={'message':"ERROR: subasta No Encontrada"}
            return JsonResponse(datos)
        else:
            subastas = list(Subasta.objects.values())
            if len(subastas) > 0:
                datos={'message':"Success","subasta":subastas}
            else:
                datos={'message':"ERROR: subastas de venta No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_subasta(monto_subasta=jd['monto_subasta'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
                if salida == 0:
                    datos = {'message':'ERORR: no fue posible agregar la subasta'}
                else:
                    datos = {'message':'Success','id_subasta':salida}
            except:
                datos = {'message':'ERROR: Validar datos'}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def put(self, request,id_subasta):
        try:
            jd = json.loads(request.body)
            subasteas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
            if len(subasteas) > 0:
                try:
                    salida = modificar_subasta(id_subasta=jd['id_subasta'],monto_subasta=jd['monto_subasta'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
                    if salida == 0:
                        datos = {'message':'ERORR: no fue posible modificar la subasta'}
                    else:
                        datos = {'message':'Success'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: No se encuentra la subasta"}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def delete(self, request,id_subasta):
        subastas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
        if len(subastas) > 0:
            try:
                salida = eliminar_subasta(id_subasta)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible eliminar la subasta'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: no se encuentra la subasta"}
        return JsonResponse(datos)

class SubastaVentaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self, request, id_venta):
        subastas=list(Subasta.objects.filter(id_venta=id_venta).values())
        if len(subastas) > 0:
            datos=subastas
        else:
            datos={'message':"ERROR: subasta No Encontrada"}
        return JsonResponse(datos,safe=False)

class SubastaViewset(viewsets.ModelViewSet):
    queryset = Subasta.objects.filter(estado_fila='1')
    serializer_class = SubastaSerializer


class SubastaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Subasta.objects.all()
    serializer_class = SubastaHistoricoSerializer