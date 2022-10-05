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

def eliminar_venta_externa(id_venta_externa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_EXTERNA_ELIMINAR',[id_venta_externa,salida])

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

    def get(self, request, id_venta_externa=0):
        if(id > 0):
            ventas=list(VentaExterna.objects.filter(id_venta_externa=id_venta_externa).values())
            if len(ventas) > 0:
                venta = ventas[0]
                datos={'message':"Success","venta_externa":venta}
            else:
                datos={'message':"ERROR: venta No Encontrada"}
            return JsonResponse(datos)
        else:
            ventas = list(VentaExterna.objects.values())
            if len(ventas) > 0:
                datos={'message':"Success","venta_externa":ventas}
            else:
                datos={'message':"ERROR: ventas de ventas No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_venta_externa(descripcion_venta=jd['descripcion_venta'],estado_venta=jd['estado_venta'],monto_bruto_venta=jd['monto_bruto_venta'],iva=jd['iva'],monto_neto_venta=jd['monto_neto_venta'],id_empresa=jd['id_empresa'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_venta_externa):
        jd = json.loads(request.body)
        ventas = list(VentaExterna.objects.filter(id_venta_externa=id_venta_externa).values())
        if len(ventas) > 0:
            modificar_venta_externa(id_venta_externa=jd['id_venta_externa'],descripcion_venta=jd['descripcion_venta'],estado_venta=jd['estado_venta'],monto_bruto_venta=jd['monto_bruto_venta'],iva=jd['iva'],monto_neto_venta=jd['monto_neto_venta'],id_empresa=jd['id_empresa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la venta"}
        return JsonResponse(datos)

    def delete(self, request,id_venta_externa):
        ventas = list(VentaExterna.objects.filter(id_venta_externa=id_venta_externa).values())
        jd = json.loads(request.body)
        if len(ventas) > 0:
            eliminar_venta_externa(id_venta_externa=jd['id_venta_externa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar la venta"}
        return JsonResponse(datos)

class VentaExternaViewset(viewsets.ModelViewSet):
    queryset = VentaExterna.objects.filter(estado_fila='1')
    serializer_class = VentaExternaSerializer


class VentaExternaHistoricoViewset(viewsets.ModelViewSet):
    queryset = VentaExterna.objects.all()
    serializer_class = VentaExternaHistoricoSerializer