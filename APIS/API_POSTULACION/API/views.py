from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Postulacion
from .serializers import PostulacionSerializer,PostulacionHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_postulacion(descripcion_postulacion,estado_postulacion,id_venta,id_usuario,id_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '0'
    cursor.callproc('POSTULACION_AGREGAR',[descripcion_postulacion,estado_postulacion,id_venta,id_usuario,id_producto,estado_fila,salida])
    return salida

def modificar_postulacion(id_postulacion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('POSTULACION_MODIFICAR',[id_postulacion,salida])

def eliminar_postulacion(id_postulacion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('POSTULACION_ELIMINAR',[id_postulacion,salida])

def lista_postulacion():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('POSTULACION_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class PostulacionView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_postulacion=0):
        if(id_postulacion > 0):
            postulaciones=list(Postulacion.objects.filter(id_postulacion=id_postulacion).values())
            if len(postulaciones) > 0:
                postulacion = postulaciones[0]
                datos={'message':"Success","postulacion":postulacion}
            else:
                datos={'message':"ERROR: postulacion No Encontrada"}
            return JsonResponse(datos)
        else:
            postulaciones = list(Postulacion.objects.values())
            if len(postulaciones) > 0:
                datos={'message':"Success","postulaciones":postulaciones}
            else:
                datos={'message':"ERROR: postulaciones No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_postulacion(descripcion_postulacion=jd['descripcion_postulacion'],estado_postulacion=jd['estado_postulacion'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'],id_producto=jd['id_producto'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_postulacion):
        jd = json.loads(request.body)
        postulaciones = list(Postulacion.objects.filter(id_postulacion=id_postulacion).values())
        if len(postulaciones) > 0:
            modificar_postulacion(id_postulacion=jd['id_postulacion'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra la postulacion"}
        return JsonResponse(datos)

    def delete(self, request,id_postulacion):
        postulaciones = list(Postulacion.objects.filter(id_postulacion=id_postulacion).values())
        jd = json.loads(request.body)
        if len(postulaciones) > 0:
            eliminar_postulacion(id_postulacion=jd['id_postulacion'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar la postulacion"}
        return JsonResponse(datos)

class PostulacionesViewset(viewsets.ModelViewSet):
    queryset = Postulacion.objects.filter(estado_fila='1')
    serializer_class = PostulacionSerializer


class PostulacionesHistoricoViewset(viewsets.ModelViewSet):
    queryset = Postulacion.objects.all()
    serializer_class = PostulacionHistoricoSerializer