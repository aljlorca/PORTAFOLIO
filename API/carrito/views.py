from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Carrito
from .serializers import CarritoSerializer,CarritoHistoricoSerializer
from rest_framework import viewsets
import json
import datetime
import cx_Oracle
# Create your views here.


def agregar_carrito(monto_carrito,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    fecha_carrito = datetime.date.today()
    estado_fila = '1'
    cursor.callproc('CARRITO_AGREGAR',[fecha_carrito,monto_carrito,id_usuario,estado_fila,salida])
    return round(salida.getvalue())

def modificar_carrito(id_carrito,fecha_carrito,monto_carrito,id_producto,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARRITO_MODIFICAR',[id_carrito,fecha_carrito,monto_carrito,id_producto,id_usuario,salida])
    return round(salida.getvalue())

def eliminar_carrito(id_carrito):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARRITO_ELIMINAR',[id_carrito,salida])
    return round(salida.getvalue())

def lista_carrito():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CARRITO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class CarritoView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_carrito=0):
        if(id_carrito > 0):
            carritos=list(Carrito.objects.filter(id_carrito=id_carrito).values())
            if len(carritos) > 0:
                carrito = carritos[0]
                datos={'message':"Success",'carrito':carrito}
            else:
                datos={'message':"ERROR: carrito No Encontrado"}
            return JsonResponse(datos)
        else:
            carritos = list(Carrito.objects.values())
            if len(carritos) > 0:
                datos={'message':"Success",'carritos':carritos}
            else:
                datos={'message':"ERROR: carritos No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_carrito(monto_carrito=jd['monto_carrito'],id_usuario=jd['id_usuario'])
                if salida == 1:
                    datos = {'message':'Success'}
                elif salida == 0:
                    datos = {'message':'ERROR: No fue posible registrar el carrito'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        except:
            datos = {'message':'ERORR: Json invalido'}
        return JsonResponse(datos)
        

    def put(self, request,id_carrito):
        try:
            jd = json.loads(request.body)
            cargos = list(Carrito.objects.filter(id_carrito=id_carrito).values())
            if len(cargos) > 0:
                try:
                    salida = modificar_carrito(id_carrito=jd['id_carrito'],fecha_carrito=jd['fecha_carrito'],monto_carrito=jd['monto_carrito'],id_producto=jd['id_producto'],id_usuario=jd['id_usuario'])
                    if salida == 1:
                        datos={'message':"Success"}
                    elif salida == 0:
                        datos={'message':'ERROR: No fue posible modificar el carrito'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: No se encuentra el carrito"}
        except:
            datos = {'message':'ERORR: Json invalido'}
        return JsonResponse(datos)

    def delete(self, request,id_carrito):
        carritos = list(Carrito.objects.filter(id_carrito=id_carrito).values())
        if len(carritos) > 0:
            try:
                salida = eliminar_carrito(id_carrito)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos={'message':'ERROR: no fue posible eliminar el carrito'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: no se encuentra el carrito"}
        return JsonResponse(datos)
    
    
class CarritoViewset(viewsets.ModelViewSet):
    queryset = Carrito.objects.filter(estado_fila='1')
    serializer_class = CarritoSerializer


class CarritoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Carrito.objects.all()
    serializer_class = CarritoHistoricoSerializer
