from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Region
from .serializers import RegionSerializer,RegionHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_region(nombre_region,id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('REGION_AGREGAR',[nombre_region,id_pais,estado_fila,salida])
    return round(salida.getvalue())

def modificar_region(id_region,nombre_region,id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('REGION_MODIFICAR',[id_region,nombre_region,id_pais,salida])
    return round(salida.getvalue())

def eliminar_region(id_region):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('REGION_ELIMINAR',[id_region,salida])
    return round(salida.getvalue())

def lista_region():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('REGION_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class RegionView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_region=0):
        if(id_region > 0):
            regiones=list(Region.objects.filter(id_region=id_region).values())
            if len(regiones) > 0:
                region = regiones[0]
                datos={'message':"Success",'Region':region}
            else:
                datos={'message':"ERROR: Region No Encontrada"}
            return JsonResponse(datos)
        else:
            regiones = list(Region.objects.values())
            if len(regiones) > 0:
                datos={'message':"Success",'Regiones':regiones}
            else:
                datos={'message':"ERROR: regiones No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_region(nombre_region=jd['nombre_region'],id_pais=jd['id_pais'])
                if salida == 1:
                    datos = {'message':'Success'}
                elif salida == 0:
                    datos = {'message':'ERORR: No fue posible agregar la region'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def put(self, request,id_region):
        try:
            jd = json.loads(request.body)
            regiones = list(Region.objects.filter(id_region=id_region).values())
            if len(regiones) > 0:
                try:
                    salida = modificar_region(id_region=jd['id_region'],nombre_region=jd['nombre_region'],id_pais=jd['id_pais'])
                    if salida == 1:
                        datos={'message':"Success"}
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posiuble modificar la region'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: No se encuentra la region"}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def delete(self, request,id_region):
        regiones = list(Region.objects.filter(id_region=id_region).values())
        if len(regiones) > 0:
            try:
                salida = eliminar_region(id_region)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible eliminar la region'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else: 
            datos={'message':"ERROR: no se encuentra la region"}
        return JsonResponse(datos)
    
    
class RegionViewset(viewsets.ModelViewSet):
    queryset = Region.objects.filter(estado_fila='1')
    serializer_class = RegionSerializer


class RegionHistoricoViewset(viewsets.ModelViewSet):
    queryset = Region.objects.all()
    serializer_class = RegionHistoricoSerializer