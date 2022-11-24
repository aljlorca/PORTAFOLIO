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


def agregar_carga(capacidad_carga,refrigeracion_carga,tamano_carga,id_subasta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('CARGA_AGREGAR',[capacidad_carga,refrigeracion_carga,tamano_carga,id_subasta,id_usuario,estado_fila,salida])
    return round(salida.getvalue())

def modificar_carga(id_carga,capacidad_carga,refrigeracion_carga,tamano_carga,id_subasta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGA_MODIFICAR',[id_carga,capacidad_carga,refrigeracion_carga,tamano_carga,id_subasta,id_usuario,salida])
    return round(salida.getvalue())

def eliminar_carga(id_carga):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGA_ELIMINAR',[id_carga,salida])
    return round(salida.getvalue())

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
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: carga No Encontrada"}
                return JsonResponse(datos, status=404)
        else:
            cargas = list(Carga.objects.values())
            if len(cargas) > 0:
                datos={'message':"Success",'cargas':cargas}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: cargas No encontrados"}
                return JsonResponse(datos, status=404)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try: 
                salida = agregar_carga(capacidad_carga=jd['capacidad_carga'],refrigeracion_carga=jd['refrigeracion_carga'],tamano_carga=jd['tamano_carga'],id_subasta=jd['id_subasta'],id_usuario=jd['id_usuario'])
                if salida == 1:
                    datos = {'message':'Success'}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERROR: No fue posible registrar la carga'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=500)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)        

    def put(self, request,id_carga):
        try:
            jd = json.loads(request.body)
            cargas = list(Carga.objects.filter(id_carga=id_carga).values())
            if len(cargas) > 0:
                try:
                    salida = modificar_carga(id_carga=jd['id_carga'],capacidad_carga=jd['capacidad_carga'],refrigeracion=jd['refrigeracion'],tamano_carga=jd['tamano_carga'],id_subasta=jd['id_subasta'],id_usuario=jd['id_usuario'])
                    if salida == 1:
                        datos={'message':"Success"}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos = {'message':'ERROR: No fue posible actualizar la carga'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else: 
                datos={'message':"ERROR: No se encuentra la carga"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def delete(self, request,id_carga):
        cargas = list(Carga.objects.filter(id_carga=id_carga).values())
        if len(cargas) > 0:
            try: 
                salida = eliminar_carga(id_carga)
                if salida == 1:
                    datos={'message':"Success"}
                    return JsonResponse(datos, status=201)
                elif salida == 0: 
                    datos={'message':"ERROR: no fue posible eliminar la carga"}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=404)
        else:
            datos={'message':"ERROR: No se encuentra la carga"}
            return JsonResponse(datos, status=404)

class CargaSubastaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_subasta):
            cargas=list(Carga.objects.filter(id_subasta=id_subasta).order_by('id_carga').values())
            if len(cargas) > 0:
                carga = cargas[0]
                datos={'carga':carga}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: carga No Encontrada"}
            return JsonResponse(datos, status=404)
    
class CargaViewset(viewsets.ModelViewSet):
    queryset = Carga.objects.all()
    serializer_class = CargaSerializer

