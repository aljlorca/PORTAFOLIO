from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Cargo
import cx_Oracle
import json
# Create your views here.


def agregar_cargo(nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_AGREGAR',[nombre])

def modificar_cargo(id,nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_MODIFICAR',[id,nombre])

def eliminar_cargo(id):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_ELIMINAR',[id])
    

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
        #print(request.body)
        jd = json.loads(request.body)
        print(jd)
        agregar_cargo(nombre=jd['nombre_cargo'])
        datos={'message':"Success"}
        return JsonResponse(datos)
    def put(self, request,id):
        jd = json.loads(request.body)
        cargos = list(Cargo.objects.filter(id=id).values())
        if len(cargos) > 0:
            modificar_cargo(id=jd['id_cargo'],nombre=jd['nombre_cargo'],)
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





    