from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import VentaExterna
from .serializers import VentaExternaSerializer,VentaExternaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
import datetime

# Create your views here.
def agregar_venta_externa(descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta = datetime.date.today()
    estado_fila = '1'
    cursor.callproc('VENTA_EXTERNA_AGREGAR',[descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,id_empresa,estado_fila,salida])
    return salida

def modificar_venta_externa(id_venta_externa,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta = datetime.date.today()
    cursor.callproc('VENTA_EXTERNA_MODIFICAR',[id_venta_externa,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,id_empresa,salida])

def eliminar_venta_externa(id_subasta_transportista):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_EXTERNA_ELIMINAR',[id_subasta_transportista,salida])

def lista_venta_externa():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('VENTA_EXTERNA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class VentaExternaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_subasta_transportista=0):
        if(id > 0):
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

class VentaExternaViewset(viewsets.ModelViewSet):
    queryset = VentaExterna.objects.filter(estado_fila='1')
    serializer_class = VentaExternaSerializer


class VentaExternaHistoricoViewset(viewsets.ModelViewSet):
    queryset = VentaExterna.objects.all()
    serializer_class = VentaExternaHistoricoSerializer