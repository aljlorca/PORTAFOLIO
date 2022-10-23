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
def agregar_pedido(descripcion_pedido,fecha_sla_pedido,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('PEDIDO_AGREGAR',[descripcion_pedido,fecha_sla_pedido,id_usuario,estado_fila,salida])
    return salida

def modificar_pedido(id_pedido,descripcion_pedido,fecha_sla_pedido,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PEDIDO_MODIFICAR',[id_pedido,descripcion_pedido,fecha_sla_pedido,id_usuario,salida])

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
        agregar_pedido(descripcion_pedido=jd['descripcion_pedido'],fecha_sla_pedido=jd['fecha_sla_pedido'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_pedido):
        jd = json.loads(request.body)
        empresas = list(Pedido.objects.filter(id_pedido=id_pedido).values())
        if len(empresas) > 0:
            modificar_pedido(id_pedido=jd['id_pedido'],descripcion_pedido=jd['descripcion_pedido'],fecha_sla_pedido=jd['fecha_sla_pedido'],id_usuario=jd['id_usuario'])
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



class PedidoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Pedido.objects.all()
    serializer_class = PedidoHistoricoSerializer