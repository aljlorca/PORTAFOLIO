from asyncio import DatagramProtocol
from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Cargo
from .serializers import CategoriaSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_cargo(nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGO_AGREGAR',[nombre,'1',salida])

def modificar_cargo(id,nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGO_MODIFICAR',[id,nombre,salida])

def eliminar_cargo(id):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGO_ELIMINAR',[id,salida])

def lista_cargo():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CARGO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class CargoView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_cargo=0):
        if(id > 0):
            cargos=list(Cargo.objects.filter(id=id_cargo).values())
            if len(cargos) > 0:
                cargo = cargos[0]
                datos={'message':"Success",'cargo':cargo}
            else:
                datos={'message':"ERROR: Cargo No Encontrado"}
            return JsonResponse(datos)
        else:
            cargos = list(Cargo.objects.values())
            if len(cargos) > 0:
                datos={'message':"Success",'cargos':cargos}
            else:
                datos={'message':"ERROR: Cargos No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        salida = agregar_cargo(nombre=jd['nombre_cargo'])
        if salida == 1:
            datos={'message':"Success"}
        else :
            datos={'message':"ERROR: No fue posible agregar el cargo"}
        return JsonResponse(datos)
    def put(self, request,id_cargo):
        jd = json.loads(request.body)
        cargos = list(Cargo.objects.filter(id=id_cargo).values())
        if len(cargos) > 0:
            salida = modificar_cargo(id_cargo=jd['id_cargo'],nombre_cargo=jd['nombre_cargo'])
            if salida == 1 :
                datos={'message':"Success"}
            else:
                datos={'message':"ERROR: no fue posible modificar el cargo"}
        else:
            datos={'message':"ERROR: No se encuentra el cargo"}
        return JsonResponse(datos)

    def delete(self, request,id_cargo):
        cargos = list(Cargo.objects.filter(id=id_cargo).values())
        if len(cargos) > 0:
            salida = eliminar_cargo(id_cargo)
            if salida == 1: 
                datos={'message':"Success"}
            if salida == 0:
                datos={'message':"ERROR: no fue posible eliminar el cargo"}
        else:
            datos={'message':"ERROR: No se pudo encontrar el cargo"}
        return JsonResponse(datos)
    
    
class CargoViewset(viewsets.ModelViewSet):
    queryset = Cargo.objects.all()
    serializer_class = CategoriaSerializer
