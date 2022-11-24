from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Cargo
from .serializers import CargoSerializer,CargoHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.


def agregar_cargo(nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('CARGO_AGREGAR',[nombre,estado_fila,salida])
    return round(salida.getvalue())

def modificar_cargo(id_cargo,nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGO_MODIFICAR',[id_cargo,nombre,salida])
    return round(salida.getvalue())

def eliminar_cargo(id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CARGO_ELIMINAR',[id_cargo,salida])
    return round(salida.getvalue())

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
        if(id_cargo > 0):
            cargos=list(Cargo.objects.filter(id=id_cargo).values())
            if len(cargos) > 0:
                cargo = cargos[0]
                datos={'message':"Success",'cargo':cargo}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: Cargo No Encontrado"}
                return JsonResponse(datos, status=404)
        else:
            cargos = list(Cargo.objects.values())
            if len(cargos) > 0:
                datos={'message':"Success",'cargos':cargos}
                return JsonResponse(datos, status=200)
            else:
                datos={'message':"ERROR: Cargos No encontrados"}
                return JsonResponse(datos, status=404)

    def post(self, request):
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_cargo(nombre=jd['nombre_cargo'])
                if salida == 1:
                    datos = {'message':'Success'}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos={'message':"ERROR: no fue posible agregar el cargo"}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)        

    def put(self, request,id_cargo):
        try:
            jd = json.loads(request.body)
            cargos = list(Cargo.objects.filter(id_cargo=id_cargo).values())
            if len(cargos) > 0:
                try:
                    salida = modificar_cargo(id_cargo=jd['id_cargo'],nombre=jd['nombre_cargo'])
                    if salida == 1:
                        datos={'message':"Success"}
                        return JsonResponse(datos, status=201)
                    elif salida == 0:
                        datos={'message':"ERROR: no fue posible modificar el cargo"}
                        return JsonResponse(datos, status=404)
                except:
                    datos = {'message':'ERROR: Validar datos'}
                    return JsonResponse(datos, status=404)
            else:
                datos={'message':"ERROR: No se encuentra el cargo"}
                return JsonResponse(datos, status=404)
        except:
            datos = {'message':'ERORR: Json invalido'}
            return JsonResponse(datos, status=500)

    def delete(self, request,id_cargo):
        cargos = list(Cargo.objects.filter(id_cargo=id_cargo).values())
        if len(cargos) > 0:
            try:
                salida = eliminar_cargo(id_cargo)
                if salida == 1:
                    datos={'message':"Success"}
                    return JsonResponse(datos, status=201)
                elif salida == 0:
                    datos = {'message':'ERROR: No fue posible eliminar el cargo'}
                    return JsonResponse(datos, status=404)
            except:
                datos = {'message':'ERROR: Validar datos'}
                return JsonResponse(datos, status=404)
        else:
            datos={'message':"ERROR: no fue posible encontrar el cargo"}
            return JsonResponse(datos, status=404)
    
    
class CargoViewset(viewsets.ModelViewSet):
    queryset = Cargo.objects.filter(estado_fila='1')
    serializer_class = CargoSerializer


class CargoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Cargo.objects.all()
    serializer_class = CargoHistoricoSerializer
