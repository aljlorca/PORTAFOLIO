from ast import Return
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


def agregar_calidad(descripcion_calidad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('CALIDAD_AGREGAR',[descripcion_calidad,estado_fila,salida])
    return round(salida.getvalue())

def modificar_calidad(id_calidad,descripcion_calidad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CALIDAD_MODIFICAR',[id_calidad,descripcion_calidad,salida])
    return round(salida.getvalue())

def eliminar_calidad(id_calidad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CALIDAD_ELIMINAR',[id_calidad,salida])
    return round(salida.getvalue())

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
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: calidad No Encontrada"}
                return JsonResponse(datos, status=404)
        else:
            calidades = list(Calidad.objects.values())
            if len(calidades) > 0:
                datos={'message':"Success",'calidades':calidades}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: calidades No encontrados"}
                return JsonResponse(datos, status=500)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_calidad(descripcion_calidad=jd['descripcion_calidad'])
                if salida == 1:
                    datos = {'message':'Success'}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERROR: no fue posible agregar la calidad'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)
        

    def put(self, request,id_calidad):
        try:
            jd = json.loads(request.body)
            calidades = list(Calidad.objects.filter(id_calidad=id_calidad).values())
            if len(calidades) > 0:
                try: 
                    salida=modificar_calidad(id_calidad=jd['id_calidad'],descripcion_calidad=jd['descripcion_calidad'])
                    if salida == 1:
                        datos = {'message':'Success'}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos = {'message':'ERROR: no fue posible actualizar la calidad'}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: No se encuentra la calidad"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def delete(self, request,id_calidad):
        calidades = list(Calidad.objects.filter(id_calidad=id_calidad).values())
        if len(calidades) > 0:
            try:
                salida = eliminar_calidad(id_calidad)
                if salida == 1:
                    datos = {'message':'Success'}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERROR: no fue posible eliminar la calidad'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=500)
        else:
            datos={'message':"ERROR: no fue posible eliminar el cargo"}
            return JsonResponse(datos, status=500)
    
    
class CalidadViewset(viewsets.ModelViewSet):
    queryset = Calidad.objects.all()
    serializer_class = CalidadSerializer

