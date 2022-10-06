from asyncio import DatagramProtocol
from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Ciudad
from .serializers import CiudadSerializer,CiudadHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_ciudad(nombre_ciudad,codigo_postal,id_region):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('CIUDAD_AGREGAR',[nombre_ciudad,codigo_postal,id_region,estado_fila,salida])
    return salida

def modificar_ciudad(id_ciudad,nombre_ciudad,codigo_postal,id_region):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CIUDAD_MODIFICAR',[id_ciudad,nombre_ciudad,codigo_postal,id_region,salida])

def eliminar_ciudad(id_ciudad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CIUDAD_ELIMINAR',[id_ciudad,salida])

def lista_ciudad():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CIUDAD_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class CiudadView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_ciudad=0):
        if(id_ciudad > 0):
            ciudades=list(Ciudad.objects.filter(id_ciudad=id_ciudad).values())
            if len(ciudades) > 0:
                ciudad = ciudades[0]
                datos={'message':"Success",'Ciudad':ciudad}
            else:
                datos={'message':"ERROR: Ciudad No Encontrada"}
            return JsonResponse(datos)
        else:
            ciudad = list(Ciudad.objects.values())
            if len(ciudad) > 0:
                datos={'message':"Success",'Ciudad':ciudad}
            else:
                datos={'message':"ERROR: ciudad No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_ciudad(nombre_ciudad=jd['nombre_ciudad'],codigo_postal=jd['codigo_postal'],id_region=jd['id_region'])
        datos = {'message':'Success'}
        return JsonResponse(datos)

    def put(self, request,id_ciudad):
        jd = json.loads(request.body)
        ciudades = list(Ciudad.objects.filter(id_ciudad=id_ciudad).values())
        if len(ciudades) > 0:
            modificar_ciudad(id_ciudad=jd['id_ciudad'],nombre_ciudad=jd['nombre_ciudad'],codigo_postal=jd['codigo_postal'],id_region=jd['id_region'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la ciudad"}
        return JsonResponse(datos)

    def delete(self, request,id_ciudad):
        ciudades = list(Ciudad.objects.filter(id_ciudad=id_ciudad).values())
        if len(ciudades) > 0:
            salida = eliminar_ciudad(id_ciudad)
            datos={'message':"Success"}
        else: 
            datos={'message':"ERROR: no fue posible eliminar la region"}
        return JsonResponse(datos)
    
    
class CiudadViewset(viewsets.ModelViewSet):
    queryset = Ciudad.objects.filter(estado_fila='1')
    serializer_class = CiudadSerializer


class CiudadHistoricoViewset(viewsets.ModelViewSet):
    queryset = Ciudad.objects.all()
    serializer_class = CiudadHistoricoSerializer