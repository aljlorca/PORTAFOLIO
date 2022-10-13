from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Carga
from .serializers import CargaSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_carga(capacidad_carga,refrigeracion,tamano_carga,id_subasta_transportista,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGA_AGREGAR',[capacidad_carga,refrigeracion,tamano_carga,id_subasta_transportista,id_usuario,salida])
    return salida

def modificar_carga(id_carga,capacidad_carga,refrigeracion,tamano_carga,id_subasta_transportista,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGA_MODIFICAR',[id_carga,capacidad_carga,refrigeracion,tamano_carga,id_subasta_transportista,id_usuario,salida])

def eliminar_carga(id_carga):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGA_ELIMINAR',[id_carga,salida])

def lista_carga():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CARGA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class CargaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_carga=0):
        if(id_carga > 0):
            cargas=list(Carga.objects.filter(id_carga=id_carga).values())
            if len(cargas) > 0:
                carga = cargas[0]
                datos={'message':"Success",'carga':carga}
            else:
                datos={'message':"ERROR: carga No Encontrada"}
            return JsonResponse(datos)
        else:
            cargas = list(Carga.objects.values())
            if len(cargas) > 0:
                datos={'message':"Success",'cargas':cargas}
            else:
                datos={'message':"ERROR: cargas No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_carga(capacidad_carga=jd['capacidad_carga'],capacidad_carga=jd['capacidad_carga'],refrigeracion=jd['refrigeracion'],tamano_carga=jd['tamano_carga'],id_subasta_transportista=jd['id_subasta_transportista'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_carga):
        jd = json.loads(request.body)
        cargas = list(Carga.objects.filter(id_carga=id_carga).values())
        if len(cargas) > 0:
            modificar_carga(id_carga=jd['id_carga'],capacidad_carga=jd['capacidad_carga'],capacidad_carga=jd['capacidad_carga'],refrigeracion=jd['refrigeracion'],tamano_carga=jd['tamano_carga'],id_subasta_transportista=jd['id_subasta_transportista'],id_usuario=jd['id_usuario'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la carga"}
        return JsonResponse(datos)

    def delete(self, request,id_carga):
        cargas = list(Carga.objects.filter(id_carga=id_carga).values())
        if len(cargas) > 0:
            salida = eliminar_carga(id_carga)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el cargo"}
        return JsonResponse(datos)
    
    
class CargaViewset(viewsets.ModelViewSet):
    queryset = Carga.objects.all()
    serializer_class = CargaSerializer

