from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from requests import Response
from .models import Producto
from .serializers import ProductoSerializer
from .algoritmo import get_mejor_producto
from django.http import HttpResponse
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.

def agregar_producto(nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,id_usuario,descripcion_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('PRODUCTO_AGREGAR',[nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,estado_fila,id_usuario,descripcion_producto,salida])
    return round(salida.getvalue())

def modificar_producto(id_producto,saldo_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PRODUCTO_SALDO',[id_producto,saldo_producto,salida])
    return round(salida.getvalue())

def eliminar_producto(id_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PRODUCTO_ELIMINAR',[id_producto,salida])
    return round(salida.getvalue())

def listar_producto():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

def producto_venta(id_venta):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PRODUCTO_VENTA', [id_venta,out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)

    lista_json=[]
    cont=0
    for dato in lista:
        fila=lista[cont]
        jd = {'id_postulacion':fila[0],
        'id_producto':fila[1],
        'cantidad_producto':fila[2],
        'precio_producto':fila[3],
        'descripcion_calidad':fila[4],}
        lista_json.append(jd)
        cont=cont+1
    return lista_json


class ProductoView(View):
    
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,id_producto='0'):
        if(id_producto!='0'):
            productos=list(Producto.objects.filter(id_producto=id_producto).values().order_by('id_calidad'))
            if len(productos) > 0:
                producto = productos[0]
                datos={'message':'Success','Producto':producto}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':'Error: producto NO Encontrado'}
                return JsonResponse(datos, status=404)
        else:
            productos = list(Producto.objects.values())
            if len(productos)>0:
                datos={'message':'Success','Productos':productos}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':'Error: Productos NO Encontrados'}
                return JsonResponse(datos, status=404)
    
    def post(self, request, *args, **kwargs):
        try: 
            id_producto = request.body['id_producto']
            nombre_producto = request.body['nombre_producto']
            cantidad_producto = request.body['cantidad_producto']
            precio_producto = request.body['precio_producto']
            imagen_producto = request.body['imagen_producto']
            id_calidad = request.body['id_calidad']
            saldo_producto = request.body['saldo_producto']
            estado_fila = request.body['estado_fila']
            id_usuario = request.body['id_usuario']
            Producto.objects.create(id_producto=id_producto, nombre_producto=nombre_producto,cantidad_producto=cantidad_producto,precio_producto=precio_producto,imagen_producto=imagen_producto,id_calidad=id_calidad,saldo_producto=saldo_producto,estado_fila=estado_fila,id_usuario=id_usuario)
            datos={'message':'Success'}
            return JsonResponse(datos, status=201)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=404)
    
    def put(self,request,id_producto):
        try:
            jd = json.loads(request.body)
            productos = list(Producto.objects.filter(id_producto=id_producto).values())
            if len(productos)>0:
                try:
                    salida = modificar_producto(id_producto=jd['id_producto'],saldo_producto=jd['saldo_producto'])
                    if salida == 1:
                        datos={'message':'Success'}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posible eliminar el producto'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':'ERROR: Producto NO encontrado'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)
    
    def delete(self,request,id_producto):
        productos = list(Producto.objects.filter(id_producto=id_producto).values())
        if len(productos) > 0:
            try:
                salida = eliminar_producto(id_producto)
                if salida == 1:
                    datos={'message':'Producto elminado: '+str(id_producto)}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible eliminar el producto'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERORR: Validar datos'}
                return JsonResponse(datos, status=404)
        else:
            datos={'message':'ERROR: No se encuentra el producto'}
            return JsonResponse(datos, status=404)



class ProductoViewset(viewsets.ModelViewSet):
    queryset = Producto.objects.filter(estado_fila = '1').order_by('id_calidad')
    serializer_class = ProductoSerializer

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        try: 
            id_producto = request.data['id_producto']
            nombre_producto = request.data['nombre_producto']
            cantidad_producto = request.data['cantidad_producto']
            precio_producto = request.data['precio_producto']
            imagen_producto = request.data['imagen_producto']
            id_calidad = request.data['id_calidad']
            saldo_producto = request.data['saldo_producto']
            estado_fila = request.data['estado_fila']
            id_usuario = request.data['id_usuario']
            descripcion_producto = request.data['descripcion_producto']
            Producto.objects.create(id_producto=id_producto, nombre_producto=nombre_producto,cantidad_producto=cantidad_producto,precio_producto=precio_producto,imagen_producto=imagen_producto,id_calidad=id_calidad,saldo_producto=saldo_producto,estado_fila=estado_fila,id_usuario=id_usuario,descripcion_producto=descripcion_producto)
            datos={'message':'Success'}
            return JsonResponse(datos, status=201)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=404)

    def put(self, request, *args, **kwargs):
        try:
            id_producto = request.data['id_producto']
            nombre_producto = request.data['nombre_producto']
            cantidad_producto = request.data['cantidad_producto']
            precio_producto = request.data['precio_producto']
            imagen_producto = request.data['imagen_producto']
            id_calidad = request.data['id_calidad']
            saldo_producto = request.data['saldo_producto']
            estado_fila = request.data['estado_fila']
            id_usuario = request.data['id_usuario']
            descripcion_producto = request.data['descripcion_producto']
            Producto.objects.update(id_producto=id_producto, nombre_producto=nombre_producto,cantidad_producto=cantidad_producto,precio_producto=precio_producto,imagen_producto=imagen_producto,id_calidad=id_calidad,saldo_producto=saldo_producto,estado_fila=estado_fila,id_usuario=id_usuario,descripcion_producto=descripcion_producto)
            datos = {'message': 'Success'}
            return JsonResponse(datos, status=201)
        except: 
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=404)

    def delete(self, request, *args, **kwargs):
        id_producto = request.data['id_producto']
        try:
            salida = eliminar_producto(id_producto)
            if salida == 1:
                datos={'message':'Success'}
                return JsonResponse(datos, status=201)
            elif salida == 0:
                datos={'message':'ERROR: no fue posible eliminar el contrato'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERROR: Validar datos'}
            return JsonResponse(datos, status=404)

class ProductoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Producto.objects.all()
    serializer_class = ProductoSerializer

class ProductoVentaView(View):
    
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,id_venta):
        if(id_venta!=0):
            try:
                productos = producto_venta(id_venta)
                return JsonResponse(productos, status=200,safe=False)
            except:
                return JsonResponse({'message':'Error: no se encontraron productos'}, status=404)
            
        else:
            
            return JsonResponse({'message':'Error: Debes ingresar una id para la petición'}, status=500)
    
class ProductoBest(View):

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,id_venta):
        if(id_venta!=0):
            #try:
                productos = get_mejor_producto(id_venta)
                return JsonResponse(productos, status=200,safe=False)
            #except:
                return JsonResponse({'message':'Error: no se encontraron productos'}, status=404)
        else:
            return JsonResponse({'message':'Error: Debes ingresar una id para la petición'}, status=500)
