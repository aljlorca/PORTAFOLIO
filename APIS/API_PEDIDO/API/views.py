from django.db import connection
from django.http.response import JsonResponse,HttpResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Pedido
from .serializers import PedidoSerializer,PedidoHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_pedido(descripcion_pedido,documento_pedido,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PEDIDO_AGREGAR',[descripcion_pedido,documento_pedido,id_usuario,salida])
    return salida

def modificar_pedido(id_pedido,descripcion_pedido,documento_pedido,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PEDIDO_MODIFICAR',[id_pedido,descripcion_pedido,documento_pedido,id_usuario,salida])

def eliminar_pedido(id_pedido):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PEDIDO_ELIMINAR',[id_pedido,salida])

def lista_pedido():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PEDIDO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class PedidoView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_pedido=0):
        if(id_pedido > 0):
            pedidos=list(Pedido.objects.filter(id_pedido=id_pedido).values())
            if len(pedidos) > 0:
                pedido = pedidos[0]
                datos={'message':"Success","pedido":pedido}
            else:
                datos={'message':"ERROR: Pedido No Encontrado"}
            return JsonResponse(datos)
        else:
            pedidos = list(Pedido.objects.values())
            if len(pedidos) > 0:
                datos={'message':"Success","pedidos":pedidos}
            else:
                datos={'message':"ERROR: pedidos No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_pedido(descripcion_pedido=jd['descripcion_pedido'],documento_pedido=jd['documento_pedido'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_pedido):
        jd = json.loads(request.body)
        empresas = list(Pedido.objects.filter(id_pedido=id_pedido).values())
        if len(empresas) > 0:
            modificar_pedido(id_pedido=jd['id_pedido'],descripcion_pedido=jd['descripcion_pedido'],documento_pedido=jd['documento_pedido'],id_usuario=jd['id_usuario'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el pedido"}
        return JsonResponse(datos)

    def delete(self, request,id_pedido):
        pedidos = list(Pedido.objects.filter(id_pedido=id_pedido).values())
        jd = json.loads(request.body)
        if len(pedidos) > 0:
            eliminar_pedido(id_pedido=jd['id_pedido'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el pedido"}
        return JsonResponse(datos)

class PedidoViewset(viewsets.ModelViewSet):
    queryset = Pedido.objects.filter(estado_fila='1')
    serializer_class = PedidoSerializer

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def post(self, request, *args, **kwargs):
        id_pedido = request.data['id_pedido']
        descripcion_pedido = request.data['descripcion_pedido']
        documento_pedido = request.data['documento_pedido']
        id_usuario = request.data['id_usuario']
        Pedido.objects.create(id_pedido=id_pedido, descripcion_pedido=descripcion_pedido,documento_pedido=documento_pedido,id_usuario=id_usuario)
        return HttpResponse({'message': 'Success'}, status=201)
    def put(self, request, *args, **kwargs):
        id_pedido = request.data['id_pedido']
        descripcion_pedido = request.data['descripcion_pedido']
        documento_pedido = request.data['documento_pedido']
        id_usuario = request.data['id_usuario']
        Pedido.objects.update(id_pedido=id_pedido, descripcion_pedido=descripcion_pedido,documento_pedido=documento_pedido,id_usuario=id_usuario)
        return HttpResponse({'message': 'Success'}, status=200)
    def delete(self, request, *args, **kwargs):
        id_contrato = request.data['id_contrato']
        eliminar_pedido(id_contrato)
        return HttpResponse({'message': 'Success'}, status=200)


class PedidoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Pedido.objects.all()
    serializer_class = PedidoHistoricoSerializer