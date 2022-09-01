from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Cargo
import cx_Oracle
import json
# Create your views here.


def lista_cargo():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CARGO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def agregar_cargo(nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_AGREGAR',[nombre])


class CargoView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request):
        cargos = list(Cargo.objects.values())
        if len(cargos)>0:
            datos={'message':"Success",'cargos':cargos}
        else:
            datos={'message':"ERROR: Cargos No encontrados"}
        return JsonResponse(datos)

    def post(self, request):
        print(request.body)
        #jd = json.loads(request.body)
        #print(jd)
        #agregar_cargo(nombre=jd['nombre'])
        datos={'message':"Success"}
        return JsonResponse(datos)
    def put(self, request):
        pass
    def delete(self, request):
        pass

    