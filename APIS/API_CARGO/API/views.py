from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Cargo
from .serializers import CategoriaSerializer
from rest_framework import viewsets
import json
# Create your views here.


def agregar_cargo(nombre,descripcion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_AGREGAR',[nombre,descripcion])

def modificar_cargo(id,nombre,descripcion):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_MODIFICAR',[id,nombre,descripcion])

def eliminar_cargo(id):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_ELIMINAR',[id])

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

    def get(self, request, id=0):
        if(id > 0):
            cargos=list(Cargo.objects.filter(id=id).values())
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
        agregar_cargo(nombre=jd['nombre_cargo'],descripcion=jd['descripcion'])
        datos={'message':"Success"}
        return JsonResponse(datos)
    def put(self, request,id):
        jd = json.loads(request.body)
        cargos = list(Cargo.objects.filter(id=id).values())
        if len(cargos) > 0:
            modificar_cargo(id=jd['id'],nombre=jd['nombre_cargo'],descripcion=jd['descripcion'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo modificar el Cargo"}
        return JsonResponse(datos)

    def delete(self, request,id):
        cargos = list(Cargo.objects.filter(id=id).values())
        if len(cargos) > 0:
            eliminar_cargo(id)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo eliminar el Cargo"}
        return JsonResponse(datos)
    
    
class CargoViewset(viewsets.ModelViewSet):
    queryset = Cargo.objects.all()
    serializer_class = CategoriaSerializer
