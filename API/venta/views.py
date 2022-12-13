from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from rest_framework import status
from rest_framework.response import Response
from .reporte import llenado_venta
from .models import Venta
from .serializers import VentaSerializer,VentaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
import datetime

# Create your views here.
def agregar_venta(id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,tipo_venta,id_usuario,fecha_venta,cantidad_venta,monto_transporte,monto_aduanas,pago_servicio,comision_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('VENTA_AGREGAR',[id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,tipo_venta,id_usuario,cantidad_venta,monto_transporte,monto_aduanas,pago_servicio,comision_venta,estado_fila,salida])
    return round(salida.getvalue())

def modificar_venta(id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,tipo_venta,id_usuario,cantidad_venta,monto_transporte,monto_aduanas,pago_servicio,comision_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_venta = datetime.date.today()
    cursor.callproc('VENTA_MODIFICAR',[id_venta,descripcion_venta,estado_venta,monto_bruto_venta,iva,monto_neto_venta,fecha_venta,tipo_venta,id_usuario,cantidad_venta,monto_transporte,monto_aduanas,pago_servicio,comision_venta,salida])
    return round(salida.getvalue())

def reporte_venta(id_venta,monto_bruto_venta,iva,monto_neto_venta,cantidad_venta,monto_transporte,monto_aduanas,pago_servicio,comision_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_REPORTE',[id_venta,monto_bruto_venta,iva,monto_neto_venta,cantidad_venta,monto_transporte,monto_aduanas,pago_servicio,comision_venta,salida])
    return round(salida.getvalue())

def eliminar_venta(id_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_ELIMINAR',[id_venta,salida])
    return round(salida.getvalue())

def venta_cliente(id_venta,estado_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('VENTA_CLIENTE',[id_venta,estado_venta,salida])
    return round(salida.getvalue())

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
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: venta No Encontrada"}
                return JsonResponse(datos, status=404)
        else:
            ventas = list(Venta.objects.values())
            if len(ventas) > 0:
                datos={'message':"Success","venta":ventas}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: ventas de ventas No encontradas"}
                return JsonResponse(datos, status=404)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_venta(id_venta=jd['id_venta'],
                descripcion_venta=jd['descripcion_venta'],
                estado_venta=jd['estado_venta'],
                monto_bruto_venta=jd['monto_bruto_venta'],
                iva=jd['iva'],monto_neto_venta=jd['monto_neto_venta'],
                tipo_venta=jd['tipo_venta'],id_usuario=jd['id_usuario'],fecha_venta=jd['fecha_venta'],
                cantidad_venta=jd['cantidad_venta'],monto_transporte=jd['monto_transporte'],monto_aduanas=jd['monto_aduanas'],pago_servicio=jd['pago_servicio'],comision_venta=jd['comision_venta'])
                if salida == 1:
                    datos = {'message':'Success'}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible agregar la venta'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)
        

    def put(self, request,id_venta):
        try:
            jd = json.loads(request.body)
            ventas = list(Venta.objects.filter(id_venta=id_venta).values())
            if len(ventas) > 0:
                try:
                    salida = modificar_venta(id_venta=jd['id_venta'],descripcion_venta=jd['descripcion_venta'],estado_venta=jd['estado_venta'],monto_bruto_venta=jd['monto_bruto_venta'],iva=jd['iva'],monto_neto_venta=jd['monto_neto_venta'],tipo_venta=jd['tipo_venta'],id_usuario=jd['id_usuario'],cantidad_venta=jd['cantidad_venta'],monto_transporte=jd['monto_transporte'],monto_aduanas=jd['monto_aduanas'],pago_servicio=jd['pago_servicio'],comision_venta=jd['comision_venta'])
                    if salida == 1:
                        datos={'message':"Success"}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posible modificar la venta'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: No se encuentra la venta"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def delete(self, request,id_venta):
        try:
            ventas = list(Venta.objects.filter(id_venta=id_venta).values())
            jd = json.loads(request.body)
            if len(ventas) > 0:
                try:
                    salida = eliminar_venta(id_venta=jd['id_venta'])
                    if salida == 1:
                        datos={'message':"Success"}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posible elimiar la venta'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: no se encuentra la venta"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

class VentaClienteAceptar(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def put(self, request,id_venta):
        try:
            salida = venta_cliente(id_venta,estado_venta='Aceptada')
            if salida == 1:
                datos = {'message':'Success'}
                return JsonResponse(datos, status=201)
            elif salida == 0:
                datos = {'message':'ERORR: no fue posible agregar la venta'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=404)


class VentaClienteRechazar(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def put(self, request,id_venta):
        try:
            salida = venta_cliente(id_venta,estado_venta='Rechazada')
            if salida == 1:
                datos = {'message':'Success'}
                return JsonResponse(datos, status=201)
            elif salida == 0:
                datos = {'message':'ERORR: no fue posible agregar la venta'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=404)

            
class VentaReporte(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self,request,id_venta):
       # try:
            jd = llenado_venta(id_venta)
            #try:
            salida = reporte_venta(id_venta,
            monto_bruto_venta=jd['monto_bruto_venta'],
            iva=jd['iva'],
            monto_neto_venta=jd['monto_neto_venta'],
            cantidad_venta=jd['cantidad_venta'],
            monto_transporte=jd['monto_transporte'],
            monto_aduanas=jd['monto_aduanas'],
            pago_servicio=jd['pago_servicio'],
            comision_venta=jd['comision_venta'])
            if salida == 1:
                datos = {'message':'Success'}
                return JsonResponse(datos, status=201)
            elif salida == 0:
                datos = {'message':'ERORR: no fue posible agregar la venta'}
                return JsonResponse(datos, status=404)
            #except:
                #datos = {'message':'ERROR: Validar datos'}
                #return JsonResponse(datos, status=404)
        #except:
         #   datos = {'message':'ERORR: Json invalido'}
          #  return JsonResponse(datos, status=500)
            

class VentaViewset(viewsets.ModelViewSet):
    queryset = Venta.objects.filter(estado_fila='1')
    serializer_class = VentaSerializer

class VentaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Venta.objects.all()
    serializer_class = VentaHistoricoSerializer