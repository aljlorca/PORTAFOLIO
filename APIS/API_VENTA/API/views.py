from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Venta
from .serializers import VentaSerializer,VentaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
import datetime

# Create your views here.
def agregar_venta(descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,tipo_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta = datetime.date.today()
    estado_fila = '1'
    cursor.callproc('VENTA_AGREGAR',[descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,estado_fila,tipo_venta,id_usuario,salida])
    return salida

def modificar_venta(id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,tipo_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta = datetime.date.today()
    cursor.callproc('VENTA_MODIFICAR',[id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,tipo_venta,id_usuario,salida])

def eliminar_venta(id_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_ELIMINAR',[id_venta,salida])

def lista_venta():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('VENTA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class VentaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_venta=0):
        if(id_venta > 0):
            ventas=list(Venta.objects.filter(id_venta=id_venta).values())
            if len(ventas) > 0:
                venta = ventas[0]
                datos={'message':"Success","venta":venta}
            else:
                datos={'message':"ERROR: venta No Encontrada"}
            return JsonResponse(datos)
        else:
            ventas = list(Venta.objects.values())
            if len(ventas) > 0:
                datos={'message':"Success","venta":ventas}
            else:
                datos={'message':"ERROR: ventas de ventas No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_venta(descripcion_venta=jd['descripcion_venta'],estado_venta=jd['estado_venta'],monto_bruto_venta=jd['monto_bruto_venta'],iva=jd['iva'],monto_neto_venta=jd['monto_neto_venta'],tipo_venta=jd['tipo_venta'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_venta):
        jd = json.loads(request.body)
        ventas = list(Venta.objects.filter(id_venta=id_venta).values())
        if len(ventas) > 0:
            modificar_venta(id_venta=jd['id_venta'],descripcion_venta=jd['descripcion_venta'],estado_venta=jd['estado_venta'],monto_bruto_venta=jd['monto_bruto_venta'],iva=jd['iva'],monto_neto_venta=jd['monto_neto_venta'],id_empresa=jd['id_empresa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la venta"}
        return JsonResponse(datos)

    def delete(self, request,id_venta):
        ventas = list(Venta.objects.filter(id_venta=id_venta).values())
        jd = json.loads(request.body)
        if len(ventas) > 0:
            eliminar_venta(id_venta=jd['id_venta'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar la venta"}
        return JsonResponse(datos)

class VentaViewset(viewsets.ModelViewSet):
    queryset = Venta.objects.filter(estado_fila='1')
    serializer_class = VentaSerializer


class VentaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Venta.objects.all()
    serializer_class = VentaHistoricoSerializer