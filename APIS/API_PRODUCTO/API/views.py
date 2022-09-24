from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Producto
from .serializers import ProductoSerializer
from rest_framework import viewsets
import json
# Create your views here.

def agregar_producto(nombre_producto,cantidad_producto,rut_proveedor):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_AGREGAR',[nombre_producto,cantidad_producto,rut_proveedor])

def modificar_producto(id_producto,nombre_producto,cantidad_producto,rut_proveedor):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_MODIFICAR',[id_producto,nombre_producto,cantidad_producto,rut_proveedor])

def eliminar_producto(id_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_ELIMINAR',[id_producto])

def listar_producto():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

class ProductoViewset(viewsets.ModelViewSet):
    queryset = Producto.objects.all()
    serializer_class = ProductoSerializer

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
        agregar_producto(nombre_producto=jd['nombre_producto'],cantidad_producto=jd['cantidad_producto'],rut_proveedor=jd['rut_proveedor'],)
        datos={'message':'Success'}
        return JsonResponse(datos)
    
    def put(self,request,id_producto):
        jd = json.loads(request.body)
        productos = list(Producto.objects.filter(id_producto=id_producto).values())
        if len(productos)>0:
            modificar_producto(id_producto=jd['id_producto'],nombre_producto=jd['nombre_producto'],cantidad_producto=jd['cantidad_producto'],rut_proveedor=jd['rut_proveedor'],)
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
