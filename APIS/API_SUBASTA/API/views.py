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
def agregar_subasta(monto,id_venta_externa,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_subasta = datetime.date.today()
    estado_fila = '1'
    cursor.callproc('SUBASTA_AGREGAR',[monto,id_venta_externa,id_empresa,fecha_subasta,estado_fila,salida])
    return salida

def modificar_subasta(id_subasta_transportista,monto,id_venta_externa,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_subasta = datetime.date.today()
    cursor.callproc('SUBASTA_MODIFICAR',[id_subasta_transportista,monto,id_venta_externa,id_empresa,fecha_subasta,salida])

def eliminar_subasta(id_subasta_transportista):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SUBASTA_ELIMINAR',[id_subasta_transportista,salida])

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

    def get(self, request, id_subasta_transportista=0):
        if(id_subasta_transportista > 0):
            subastas=list(Subasta.objects.filter(id_subasta_transportista=id_subasta_transportista).values())
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
        agregar_subasta(monto=jd['monto'],id_venta_externa=jd['id_venta_externa'],id_empresa=jd['id_empresa'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_subasta_transportista):
        jd = json.loads(request.body)
        subasteas = list(Subasta.objects.filter(id_subasta_transportista=id_subasta_transportista).values())
        if len(subasteas) > 0:
            modificar_subasta(id_subasta_transportista=jd['id_subasta_transportista'],monto=jd['monto'],id_venta_externa=jd['id_venta_externa'],id_empresa=jd['id_empresa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la subasta"}
        return JsonResponse(datos)

    def delete(self, request,id_subasta_transportista):
        subastas = list(Subasta.objects.filter(id_subasta_transportista=id_subasta_transportista).values())
        jd = json.loads(request.body)
        if len(subastas) > 0:
            eliminar_subasta(id_subasta_transportista=jd['id_subasta_transportista'])
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