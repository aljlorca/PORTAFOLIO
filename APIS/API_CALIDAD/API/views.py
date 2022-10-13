from asyncio import DatagramProtocol
from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Calidad
from .serializers import CalidadSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_calidad(descripcion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CALIDAD_AGREGAR',[descripcion,salida])
    return salida

def modificar_calidad(id_calidad,descripcion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CALIDAD_MODIFICAR',[id_calidad,descripcion,salida])

def eliminar_calidad(id_calidad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CALIDAD_ELIMINAR',[id_calidad,salida])

def lista_calidad():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CALIDAD_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class CalidadView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_calidad=0):
        if(id_calidad > 0):
            calidades=list(Calidad.objects.filter(id_calidad=id_calidad).values())
            if len(calidades) > 0:
                calidad = calidades[0]
                datos={'message':"Success",'calidad':calidad}
            else:
                datos={'message':"ERROR: calidad No Encontrada"}
            return JsonResponse(datos)
        else:
            calidades = list(Calidad.objects.values())
            if len(calidades) > 0:
                datos={'message':"Success",'calidades':calidades}
            else:
                datos={'message':"ERROR: calidades No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_calidad(descripcion_calidad=jd['descripcion_calidad'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_calidad):
        jd = json.loads(request.body)
        calidades = list(Calidad.objects.filter(id_calidad=id_calidad).values())
        if len(calidades) > 0:
            modificar_calidad(id_calidad=jd['id_calidad'],descripcion_calidad=jd['descripcion_calidad'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la calidad"}
        return JsonResponse(datos)

    def delete(self, request,id_calidad):
        calidades = list(Calidad.objects.filter(id_calidad=id_calidad).values())
        if len(calidades) > 0:
            salida = eliminar_calidad(id_calidad)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el cargo"}
        return JsonResponse(datos)
    
    
class CalidadViewset(viewsets.ModelViewSet):
    queryset = Calidad.objects.all()
    serializer_class = CalidadSerializer

