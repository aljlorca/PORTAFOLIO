from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Factura
from .serializers import FacturaSerializer,FacturaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_factura(fecha_factura,monto_factura,id_usuario,id_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('FACTURA_AGREGAR',[fecha_factura,monto_factura,id_usuario,id_venta,estado_fila,salida])
    return round(salida.getvalue())

def modificar_factura(id_factura,fecha_factura,monto_factura,id_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('FACTURA_MODIFICAR',[id_factura,fecha_factura,monto_factura,id_venta,id_usuario,salida])
    return round(salida.getvalue())

def eliminar_factura(id_factura):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('FACTURA_ELIMINAR',[id_factura,salida])
    return round(salida.getvalue())

def lista_factura():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('FACTURA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class FacturaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_factura=0):
        if(id_factura > 0):
            facturas=list(Factura.objects.filter(id_factura=id_factura).values())
            if len(facturas) > 0:
                factura = facturas[0]
                datos={'message':"Success","factura":factura}
            else:
                datos={'message':"ERROR: factura No Encontrada"}
            return JsonResponse(datos)
        else:
            facturas = list(Factura.objects.values())
            if len(facturas) > 0:
                datos={'message':"Success","facturas":facturas}
            else:
                datos={'message':"ERROR: facturas No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try: 
                salida = agregar_factura(fecha_factura=jd['fecha_factura'],monto_factura=jd['monto_factura'],id_usuario=jd['id_usuario'],id_venta=jd['id_venta'])
                if salida == 1:
                    datos = {'message':'Success'}
                elif salida == 0:
                    datos = {'message':'ERROR: no fue posible registrar la factura'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)
        

    def put(self, request,id_factura):
        try:
            jd = json.loads(request.body)
            facturas = list(Factura.objects.filter(id_factura=id_factura).values())
            if len(facturas) > 0:
                try:
                    salida = modificar_factura(id_factura=jd['id_factura'],fecha_factura=jd['fecha_factura'],monto_factura=jd['monto_factura'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
                    if salida == 1:
                        datos={'message':"Success"}
                    elif salida == 0:
                        datos={'message':'ERROR: no fue posible modificar la factura'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: No se encuentra la factura"}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def delete(self, request,id_factura):
        facturas = list(Factura.objects.filter(id_factura=id_factura).values())
        if len(facturas) > 0:
            try:
                salida = eliminar_factura(id_factura)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos={'message':'ERROR: no fue posible eliminar la factura'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: no se encuentra la factura"}
        return JsonResponse(datos)

class FacturaViewset(viewsets.ModelViewSet):
    queryset = Factura.objects.filter(estado_fila='1')
    serializer_class = FacturaSerializer


class FacturaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Factura.objects.all()
    serializer_class = FacturaHistoricoSerializer