from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import ClienteInterno
from rest_framework import viewsets
from .serializers import ClienteInternoSerializer
import json

# Create your views here.

def agregar_cliente_interno(rut_cliente_interno,nombre_cliente_interno,direccion_cliente_interno,telefono_cliente_interno,correo_cliente_interno,contrasena_cliente_interno,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_INTERNO_AGREGAR',[rut_cliente_interno,nombre_cliente_interno,direccion_cliente_interno,telefono_cliente_interno,correo_cliente_interno,contrasena_cliente_interno,cargo_id_cargo])

def modificar_cliente_interno(rut_cliente_interno,nombre_cliente_interno,direccion_cliente_interno,telefono_cliente_interno,correo_cliente_interno,contrasena_cliente_interno,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('cliente_interno_modificar',[rut_cliente_interno,nombre_cliente_interno,direccion_cliente_interno,telefono_cliente_interno,correo_cliente_interno,contrasena_cliente_interno,cargo_id_cargo])

def eliminar_cliente_interno(rut_cliente_interno):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_INTERNO_ELIMINAR',[rut_cliente_interno])

def lista_cliente_interno():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CLIENTE_INTERNO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

class ClienteInternoViewset(viewsets.ModelViewSet):
    queryset = ClienteInterno.objects.all()
    serializer_class = ClienteInternoSerializer
    
    

class ClienteInternoView(View):

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, rut_cliente_interno=0):
        if(rut_cliente_interno > 0):
            clientes_internos=list(ClienteInterno.objects.filter(rut_cliente_interno=rut_cliente_interno).values())
            if len(clientes_internos) > 0:
                cliente_interno = clientes_internos[0]
                datos={'message':"Success",'Cliente':cliente_interno}
            else:
                datos={'message':"ERROR: Cliente Externo No Encontrado"}
            return JsonResponse(datos)
        else:
            clientes = list(ClienteInterno.objects.values())
            if len(clientes) > 0:
                datos={'message':"Success",'Clientes':clientes}
            else:
                datos={'message':"ERROR: Clientes No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_cliente_interno(rut_cliente_interno=jd['rut_cliente_interno'],nombre_cliente_interno=jd['nombre_cliente_interno'],direccion_cliente_interno=jd['direccion_cliente_interno'],telefono_cliente_interno=jd['telefono_cliente_interno'],correo_cliente_interno=jd['correo_cliente_interno'],contrasena_cliente_interno=jd['contrasena_cliente_interno'],cargo_id_cargo=jd['cargo_id_cargo'],)
        datos={'message':"Success"}
        return JsonResponse(datos)

    def put(self, request,rut_cliente_interno):
        jd = json.loads(request.body)
        clientes = list(ClienteInterno.objects.filter(rut_cliente_interno=rut_cliente_interno).values())
        if len(clientes) > 0:
            modificar_cliente_interno(rut_cliente_interno=jd['rut_cliente_interno'],nombre_cliente_interno=jd['nombre_cliente_interno'],direccion_cliente_interno=jd['direccion_cliente_interno'],telefono_cliente_interno=jd['telefono_cliente_interno'],correo_cliente_interno=jd['correo_cliente_interno'],contrasena_cliente_interno=jd['contrasena_cliente_interno'],cargo_id_cargo=jd['cargo_id_cargo'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo modificar el Cliente Interno"}
        return JsonResponse(datos)

    def delete(self, request,rut_cliente_interno):
        clientes = list(ClienteInterno.objects.filter(rut_cliente_interno=rut_cliente_interno).values())
        if len(clientes) > 0:
            eliminar_cliente_interno(rut_cliente_interno)
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se pudo eliminar el Cliente Interno"}
        return JsonResponse(datos)
