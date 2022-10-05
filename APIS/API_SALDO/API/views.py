from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Saldo
from .serializers import SaldoSerializer,SaldoHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_saldo(descripcion_saldo,monto_bruto_saldo,iva_saldo,monto_neto_saldo,id_venta_externa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('SALDO_AGREGAR',[descripcion_saldo,monto_bruto_saldo,iva_saldo,monto_neto_saldo,id_venta_externa,estado_fila,salida])
    return salida

def modificar_saldo(id_saldo,descripcion_saldo,monto_bruto_saldo,iva_saldo,monto_neto_saldo,id_venta_externa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SALDO_MODIFICAR',[id_saldo,descripcion_saldo,monto_bruto_saldo,iva_saldo,monto_neto_saldo,id_venta_externa,salida])

def eliminar_saldo(id_saldo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('SALDO_ELIMINAR',[id_saldo,salida])

def lista_saldo():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('SALDO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class SaldoView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_saldo=0):
        if(id_saldo > 0):
            saldos=list(Saldo.objects.filter(id_saldo=id_saldo).values())
            if len(saldos) > 0:
                saldo = saldos[0]
                datos={'message':"Success","saldo":saldo}
            else:
                datos={'message':"ERROR: reporte No Encontrado"}
            return JsonResponse(datos)
        else:
            saldos = list(Saldo.objects.values())
            if len(saldos) > 0:
                datos={'message':"Success","saldo":saldos}
            else:
                datos={'message':"ERROR: saldos de venta No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_saldo(descripcion_saldo=jd['descripcion_saldo'],monto_bruto_saldo=jd['monto_bruto_saldo'],iva_saldo=jd['iva_saldo'],monto_neto_saldo=jd['monto_neto_saldo'],id_venta_externa=jd['id_venta_externa'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_saldo):
        jd = json.loads(request.body)
        saldos = list(Saldo.objects.filter(id_saldo=id_saldo).values())
        if len(saldos) > 0:
            modificar_saldo(id_saldo=jd['id_saldo'],descripcion_saldo=jd['descripcion_saldo'],monto_bruto_saldo=jd['monto_bruto_saldo'],iva_saldo=jd['iva_saldo'],monto_neto_saldo=jd['monto_neto_saldo'],id_venta_externa=jd['id_venta_externa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el saldo"}
        return JsonResponse(datos)

    def delete(self, request,id_saldo):
        saldos = list(Saldo.objects.filter(id_saldo=id_saldo).values())
        jd = json.loads(request.body)
        if len(saldos) > 0:
            eliminar_saldo(id_saldo=jd['id_saldo'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el saldo"}
        return JsonResponse(datos)

class SaldoViewset(viewsets.ModelViewSet):
    queryset = Saldo.objects.filter(estado_fila='1')
    serializer_class = SaldoSerializer


class SaldoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Saldo.objects.all()
    serializer_class = SaldoHistoricoSerializer