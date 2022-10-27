from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Pais
from .serializers import PaisSerializer,PaisHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_pais(nombre_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('PAIS_AGREGAR',[nombre_pais,estado_fila,salida])
    return round(salida.getvalue())

def modificar_pais(id_pais,nombre_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PAIS_MODIFICAR',[id_pais,nombre_pais,salida])
    return round(salida.getvalue())

def eliminar_pais(id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('PAIS_ELIMINAR',[id_pais,salida])
    return round(salida.getvalue())

def lista_pais():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PAIS_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class PaisView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_pais=0):
        if(id_pais > 0):
            paises=list(Pais.objects.filter(id=id_pais).values())
            if len(paises) > 0:
                pais = paises[0]
                datos={'message':"Success",'Pais':pais}
            else:
                datos={'message':"ERROR: Pais No Encontrado"}
            return JsonResponse(datos)
        else:
            paises = list(Pais.objects.values())
            if len(paises) > 0:
                datos={'message':"Success",'paises':paises}
            else:
                datos={'message':"ERROR: paises No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        try:
            jd = json.loads(request.body)
        except:
            datos = {'message':'ERORR: Json invalido'}
        try:
            salida = agregar_pais(nombre_pais=jd['nombre_pais'])
            if salida == 1:
                datos = {'message':'Success'}
            elif salida == 0:
                datos = {'message':'ERORR: no fue posible agregar el pais'}
        except:
            datos = {'message':'ERROR: Validar datos'}
        return JsonResponse(datos)
        

    def put(self, request,id_pais):
        try:
            jd = json.loads(request.body)
        except:
            datos = {'message':'ERORR: Json invalido'}
        paises = list(Pais.objects.filter(id_pais=id_pais).values())
        if len(paises) > 0:
            try:
                salida = modificar_pais(id_pais=jd['id_pais'],nombre_pais=jd['nombre_pais'])
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible modificar el pais'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: No se encuentra el pais"}
        return JsonResponse(datos)

    def delete(self, request,id_pais):
        paises = list(Pais.objects.filter(id_pais=id_pais).values())
        if len(paises) > 0:
            try:
                salida = eliminar_pais(id_pais)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible eliminar el pais'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: no se encuentra el pais"}
        return JsonResponse(datos)
    
    
class PaisViewset(viewsets.ModelViewSet):
    queryset = Pais.objects.filter(estado_fila='1')
    serializer_class = PaisSerializer


class PaisHistoricoViewset(viewsets.ModelViewSet):
    queryset = Pais.objects.all()
    serializer_class = PaisHistoricoSerializer
