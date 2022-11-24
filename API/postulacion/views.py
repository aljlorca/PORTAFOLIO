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
def agregar_postulacion(descripcion_postulacion,id_venta,id_usuario,id_producto):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    estado_postulacion = 'En Licitacion'
    cursor.callproc('POSTULACION_AGREGAR',[descripcion_postulacion,estado_postulacion,id_venta,id_usuario,id_producto,estado_fila,salida])
    return round(salida.getvalue())

def modificar_postulacion(id_postulacion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('POSTULACION_ACEPTAR',[id_postulacion,salida])
    return round(salida.getvalue())

def eliminar_postulacion(id_postulacion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('POSTULACION_ELIMINAR',[id_postulacion,salida])
    return round(salida.getvalue())

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
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: postulacion No Encontrada"}
                return JsonResponse(datos, status=404)
        else:
            postulaciones = list(Postulacion.objects.values())
            if len(postulaciones) > 0:
                datos={'message':"Success","postulaciones":postulaciones}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: postulaciones No encontrados"}
                return JsonResponse(datos, status=404)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_postulacion(descripcion_postulacion=jd['descripcion_postulacion'],estado_postulacion=jd['estado_postulacion'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'],id_producto=jd['id_producto'])
                if salida == 1:
                    datos = {'message':'Success'}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERROR: no fue posible agregar la postulacion'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def put(self, request,id_postulacion):
        try:
            jd = json.loads(request.body)
            postulaciones = list(Postulacion.objects.filter(id_postulacion=id_postulacion).values())
            if len(postulaciones) > 0:
                try:
                    salida = modificar_postulacion(id_postulacion=jd['id_postulacion'])
                    if salida == 1:
                        datos={'message':"Success"}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos={'message':'ERROR: no fue posible modificar la postulacion'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: No se encuentra la postulacion"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def delete(self, request,id_postulacion):
        try:
            jd = json.loads(request.body)
            postulaciones = list(Postulacion.objects.filter(id_postulacion=id_postulacion).values())
            if len(postulaciones) > 0:
                try: 
                    salida = eliminar_postulacion(id_postulacion=jd['id_postulacion'])
                    if salida == 1:
                        datos={'message':"Success"}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posible elimiar la postulacion'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: no fue posible eliminar la postulacion"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

class PostulacionesViewset(viewsets.ModelViewSet):
    queryset = Postulacion.objects.filter(estado_fila='1')
    serializer_class = PostulacionSerializer


class PostulacionesHistoricoViewset(viewsets.ModelViewSet):
    queryset = Postulacion.objects.all()
    serializer_class = PostulacionHistoricoSerializer