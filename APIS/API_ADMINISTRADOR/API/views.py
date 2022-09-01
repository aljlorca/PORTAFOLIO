from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Administrador, Cargo
import json

# Create your views here.

def agregar_administrador(rut_administrador,nombre_administrador,direccion_administrador,telefono_administrador,correo_administrador,contrasena_administrador,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_AGREGAR',[rut_administrador,nombre_administrador,direccion_administrador,telefono_administrador,correo_administrador,contrasena_administrador,cargo_id_cargo])

def modificar_administrador(rut_administrador,nombre_administrador,direccion_administrador,telefono_administrador,correo_administrador,contrasena_administrador,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_MODIFICAR',[rut_administrador,nombre_administrador,direccion_administrador,telefono_administrador,correo_administrador,contrasena_administrador,cargo_id_cargo])

def eliminar_administrador(rut_administrador):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CARGO_ELIMINAR',[rut_administrador])

def lista_administrador():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CARGO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


    

class AdministradorView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, rut_administrador=0):
        if(id > 0):
            Administradores=list(Administrador.objects.filter(rut_administrador=rut_administrador).values())
            if len(Administradores) > 0:
                Administrador = Administradores[0]
                datos={'message':"Success",'Administrador':Administrador}
            else:
                datos={'message':"ERROR: Administrador No Encontrado"}
            return JsonResponse(datos)
        else:
            Administradores = list(Administrador.objects.values())
            print(Administradores)
            if len(Administradores) > 0:
                datos={'message':"Success",'Administradores':Administradores}
            else:
                datos={'message':"ERROR: Administradores No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        #print(request.body)
        jd = json.loads(request.body)
        agregar_administrador(rut_administrador=jd['rut_administrador'],nombre_administrador=jd['nombre_administrador'],direccion_administrador=jd['direccion_administrador'],telefono_administrador=jd['telefono_administrador'],correo_administrador=jd['correo_administrador'],contrasena_administrador=jd['contrasena_administrador'],cargo_id_cargo=jd['cargo_id_cargo'],)
        datos={'message':"Success"}
        return JsonResponse(datos)
    def put(self, request,rut):
        jd = json.loads(request.body)
        Administradores = list(Administrador.objects.filter(rut=rut).values())
        if len(Administradores) > 0:
            modificar_administrador(rut_administrador=jd['rut_administrador'],nombre_administrador=jd['nombre_administrador'],direccion_administrador=jd['direccion_administrador'],telefono_administrador=jd['telefono_administrador'],correo_administrador=jd['correo_administrador'],contrasena_administrador=jd['contrasena_administrador'],cargo_id_cargo=jd['cargo_id_cargo'],)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo modificar el Administrador"}
        return JsonResponse(datos)

    def delete(self, request,id):
        Administradores = list(Administrador.objects.filter(id=id).values())
        if len(Administradores) > 0:
            eliminar_administrador(id)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo eliminar el Adminsitrador"}
        return JsonResponse(datos)

