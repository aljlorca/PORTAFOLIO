from multiprocessing.connection import Client
from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import ClienteExterno, Cargo
import json

# Create your views here.

def agregar_cliente_externo(rut_cliente_externo,nombre_cliente_externo,direccion_cliente_externo,telefono_cliente_externo,correo_cliente_externo,contrasena_cliente_externo,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_EXTERNO_AGREGAR',[rut_cliente_externo,nombre_cliente_externo,direccion_cliente_externo,telefono_cliente_externo,correo_cliente_externo,contrasena_cliente_externo,cargo_id_cargo])

def modificar_cliente_externo(rut_cliente_externo,nombre_cliente_externo,direccion_cliente_externo,telefono_cliente_externo,correo_cliente_externo,contrasena_cliente_externo,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_EXTERNO_MODIFICAR',[rut_cliente_externo,nombre_cliente_externo,direccion_cliente_externo,telefono_cliente_externo,correo_cliente_externo,contrasena_cliente_externo,cargo_id_cargo])

def eliminar_cliente_externo(rut_cliente_externo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_EXTERNO_ELIMINAR',[rut_cliente_externo])

def lista_cliente_externo():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_EXTERNO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


    

class ClienteExternoView(View):

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, rut_cliente_externo=0):
        if(rut_cliente_externo > 0):
            clientes=list(ClienteExterno.objects.filter(rut_cliente_externo=rut_cliente_externo).values())
            if len(clientes) > 0:
                cliente = clientes[0]
                datos={'message':"Success",'Cliente':cliente}
            else:
                datos={'message':"ERROR: Cliente Externo No Encontrado"}
            return JsonResponse(datos)
        else:
            clientes = list(lista_cliente_externo())
            print(clientes)
            if len(clientes) > 0:
                datos={'message':"Success",'Clientes':clientes}
            else:
                datos={'message':"ERROR: Clientes No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        #print(request.body)
        jd = json.loads(request.body)
        agregar_cliente_externo(rut_cliente_externo=jd['rut_cliente_externo'],nombre_cliente_externo=jd['nombre_cliente_externo'],direccion_cliente_externo=jd['direccion_cliente_externo'],telefono_cliente_externo=jd['telefono_cliente_externo'],correo_cliente_externo=jd['correo_cliente_externo'],contrasena_cliente_externo=jd['contrasena_cliente_externo'],cargo_id_cargo=jd['cargo_id_cargo'],)
        datos={'message':"Success"}
        return JsonResponse(datos)

    def put(self, request,rut_cliente_externo):
        jd = json.loads(request.body)
        clientes = list(ClienteExterno.objects.filter(rut_cliente_externo=rut_cliente_externo).values())
        if len(clientes) > 0:
            modificar_cliente_externo(rut_cliente_externo=jd['rut_cliente_externo'],nombre_cliente_externo=jd['nombre_cliente_externo'],direccion_cliente_externo=jd['direccion_cliente_externo'],telefono_cliente_externo=jd['telefono_cliente_externo'],correo_cliente_externo=jd['correo_cliente_externo'],contrasena_cliente_externo=jd['contrasena_cliente_externo'],cargo_id_cargo=jd['cargo_id_cargo'],)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo modificar el Cliente Externo"}
        return JsonResponse(datos)

    def delete(self, request,rut_cliente_externo):
        clientes = list(ClienteExterno.objects.filter(rut_cliente_externo=rut_cliente_externo).values())
        if len(clientes) > 0:
            eliminar_cliente_externo(rut_cliente_externo)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo eliminar el Cliente Externo"}
        return JsonResponse(datos)

