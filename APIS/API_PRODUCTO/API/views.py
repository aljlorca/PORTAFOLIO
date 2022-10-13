from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Producto
from .serializers import ProductoSerializer,ProductoHistoricoSerializer
from django.http import HttpResponse
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.

def agregar_producto(nombre_producto,cantidad_prioducto,id_empresa,imagen_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('PRODUCTO_AGREGAR',[nombre_producto,cantidad_prioducto,id_empresa,estado_fila,imagen_producto,salida])

def modificar_producto(id_producto,nombre_producto,cantidad_prioducto,id_empresa,imagen_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('PRODUCTO_MODIFICAR',[id_producto,nombre_producto,cantidad_prioducto,id_empresa,imagen_producto,salida])

def eliminar_producto(id_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PRODUCTO_ELIMINAR',[id_producto,salida])

def listar_producto():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


class ProductoView(View):
    
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,id_producto=0):
        if(id_producto>0):
            productos=list(Producto.objects.filter(id_producto=id_producto).values())
            if len(productos) > 0:
                producto = productos[0]
                datos={'message':'Success','Producto':producto}
            else:
                datos={'message':'Error: Contrato NO Encontrado'}
            return JsonResponse(datos)
        else:
            productos = list(Producto.objects.values())
            if len(productos)>0:
                datos={'message':'Success','Productos':productos}
            else:
                datos={'message':'Error: Productos NO Encontrados'}
            return JsonResponse(datos)
    
    def post(self,request):
        jd = json.loads(request.body)
        agregar_producto(nombre_producto=jd['nombre_producto'],cantidad_prioducto=jd['cantidad_prioducto'],id_empresa=jd['id_empresa'],imagen_producto=jd['imagen_producto'])
        datos={'message':'Success'}
        return JsonResponse(datos)
    
    def put(self,request,id_producto):
        jd = json.loads(request.body)
        productos = list(Producto.objects.filter(id_producto=id_producto).values())
        if len(productos)>0:
            modificar_producto(id_producto=jd['id_producto'],nombre_producto=jd['nombre_producto'],cantidad_prioducto=jd['cantidad_prioducto'],id_empresa=jd['id_empresa'],imagen_producto=jd['imagen_producto'])
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: Producto NO fue posible actualizar sus datos'}
        return JsonResponse(datos)
    
    def delete(self,request,id_producto):
        productos = list(Producto.objects.filter(id_producto=id_producto).values())
        if len(productos) > 0:
            eliminar_producto(id_producto)
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: NO fue posible eliminar el Producto'}
        return JsonResponse(datos)



class ProductoViewset(viewsets.ModelViewSet):
    queryset = Producto.objects.filter(estado_fila = '1')
    serializer_class = ProductoSerializer

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        id_producto = request.data['id_producto']
        nombre_producto = request.data['nombre_producto']
        cantidad_prioducto = request.data['cantidad_producto']
        id_empresa = request.data['id_empresa']
        estado_fila = request.data['estado_fila']
        imagen_producto = request.data['imagen_producto']
        Producto.objects.create(id_producto=id_producto, nombre_producto=nombre_producto,cantidad_prioducto=cantidad_prioducto,id_empresa=id_empresa,estado_fila=estado_fila,imagen_producto=imagen_producto)
        return HttpResponse({'message': 'Success'}, status=200)


class ProductoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Producto.objects.filter(estado_fila = '1')
    serializer_class = ProductoHistoricoSerializer