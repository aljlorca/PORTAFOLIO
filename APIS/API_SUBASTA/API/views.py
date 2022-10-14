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
    cursor.callproc('SUBASTA_AGREGAR',[monto_subasta,id_venta,fecha_subasta,estado_fila,id_usuario,salida])
    return salida

def modificar_subasta(id_subasta,monto_subasta,id_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_subasta = datetime.date.today()
    cursor.callproc('SUBASTA_MODIFICAR',[id_subasta,monto_subasta,id_venta,fecha_subasta,id_usuario,salida])

def eliminar_subasta(id_subasta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SUBASTA_ELIMINAR',[id_subasta,salida])

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
                datos={'message':"Success","subasta":subasta}
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
        jd = json.loads(request.body)
        agregar_subasta(monto_subasta=jd['monto_subasta'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_subasta):
        jd = json.loads(request.body)
        subasteas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
        if len(subasteas) > 0:
            modificar_subasta(id_subasta=jd['id_subasta'],monto_subasta=jd['monto_subasta'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la subasta"}
        return JsonResponse(datos)

    def delete(self, request,id_subasta):
        subastas = list(Subasta.objects.filter(id_subasta=id_subasta).values())
        jd = json.loads(request.body)
        if len(subastas) > 0:
            eliminar_subasta(id_subasta=jd['id_subasta'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar la subasta"}
        return JsonResponse(datos)

class SubastaViewset(viewsets.ModelViewSet):
    queryset = Subasta.objects.filter(estado_fila='1')
    serializer_class = SubastaSerializer


class SubastaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Subasta.objects.all()
    serializer_class = SubastaHistoricoSerializer