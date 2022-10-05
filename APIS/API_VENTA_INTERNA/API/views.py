from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import VentaInterna
from .serializers import VentaInternaSerializer,VentaInternaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
import datetime

# Create your views here.
def agregar_venta_interna(descripcion_venta_interna,monto_bruto_venta_interna,iva_venta_interna,monto_neto_venta_interna,id_saldo,id_empresa,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta_interna = datetime.date.today()
    estado_fila = '1'
    cursor.callproc('VENTA_INTERNA_AGREGAR',[descripcion_venta_interna,monto_bruto_venta_interna,iva_venta_interna,monto_neto_venta_interna,fecha_venta_interna,id_saldo,id_empresa,estado_fila,id_usuario,salida])
    return salida

def modificar_venta_interna(id_venta_interna,descripcion_venta_interna,monto_bruto_venta_interna,iva_venta_interna,monto_neto_venta_interna,id_saldo,id_empresa,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta = datetime.date.today()
    cursor.callproc('VENTA_INTERNA_MODIFICAR',[id_venta_interna,descripcion_venta_interna,monto_bruto_venta_interna,iva_venta_interna,monto_neto_venta_interna,fecha_venta,id_saldo,id_empresa,id_usuario,salida])

def eliminar_venta_interna(id_venta_interna):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_INTERNA_ELIMINAR',[id_venta_interna,salida])

def lista_venta_interna():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('VENTA_INTERNA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class VentaInternaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_venta_interna=0):
        if(id > 0):
            ventas=list(VentaInterna.objects.filter(id_venta_interna=id_venta_interna).values())
            if len(ventas) > 0:
                venta = ventas[0]
                datos={'message':"Success","venta_interna":venta}
            else:
                datos={'message':"ERROR: venta No Encontrada"}
            return JsonResponse(datos)
        else:
            ventas = list(VentaInterna.objects.values())
            if len(ventas) > 0:
                datos={'message':"Success","venta_interna":ventas}
            else:
                datos={'message':"ERROR: ventas de ventas No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_venta_interna(descripcion_venta_interna=jd['descripcion_venta_interna'],monto_bruto_venta_interna=jd['monto_bruto_venta_interna'],iva_venta_interna=jd['iva_venta_interna'],monto_neto_venta_interna=jd['monto_neto_venta_interna'],id_saldo=jd['id_saldo'],id_empresa=jd['id_empresa'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_venta_interna):
        jd = json.loads(request.body)
        ventas = list(VentaInterna.objects.filter(id_venta_interna=id_venta_interna).values())
        if len(ventas) > 0:
            modificar_venta_interna(id_venta_interna=jd['id_venta_interna'],escripcion_venta_interna=jd['descripcion_venta_interna'],monto_bruto_venta_interna=jd['monto_bruto_venta_interna'],iva_venta_interna=jd['iva_venta_interna'],monto_neto_venta_interna=jd['monto_neto_venta_interna'],id_saldo=jd['id_saldo'],id_empresa=jd['id_empresa'],id_usuario=jd['id_usuario'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la venta"}
        return JsonResponse(datos)

    def delete(self, request,id_venta_interna):
        ventas = list(VentaInterna.objects.filter(id_venta_interna=id_venta_interna).values())
        jd = json.loads(request.body)
        if len(ventas) > 0:
            eliminar_venta_interna(id_venta_interna=jd['id_venta_interna'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar la venta"}
        return JsonResponse(datos)

class VentaInternaViewset(viewsets.ModelViewSet):
    queryset = VentaInterna.objects.filter(estado_fila='1')
    serializer_class = VentaInternaSerializer


class VentaInternaHistoricoViewset(viewsets.ModelViewSet):
    queryset = VentaInterna.objects.all()
    serializer_class = VentaInternaHistoricoSerializer