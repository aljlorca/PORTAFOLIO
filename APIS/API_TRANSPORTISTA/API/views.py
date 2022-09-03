from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Transportista
from .serializers import TransportistaSerializer
from rest_framework import viewsets
import json
# Create your views here.

def agregar_transportista(rut_transportista,nombre_transportista,direccion_transportista,telefono_transportista,correo_transportista,contrasena_transportista,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('TRANSPORTISTA_AGREGAR',[rut_transportista,nombre_transportista,direccion_transportista,telefono_transportista,correo_transportista,contrasena_transportista,cargo_id_cargo])

def modificar_transportista(rut_transportista,nombre_transportista,direccion_transportista,telefono_transportista,correo_transportista,contrasena_transportista,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('TRANSPORTISTA_MODIFICAR',[rut_transportista,nombre_transportista,direccion_transportista,telefono_transportista,correo_transportista,contrasena_transportista,cargo_id_cargo])

def eliminar_transportista(rut_transportista):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('TRANSPORTISTA_ELIMINAR',[rut_transportista])

def listar_proveedor():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('TRANSPORTISTA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

class TransportistaViewset(viewsets.ModelViewSet):
    queryset = Transportista.objects.all()
    serializer_class = TransportistaSerializer

class TransportistaView(View):
    
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,rut_transportista=0):
        if(rut_transportista>0):
            transportistas=list(Transportista.objects.filter(rut_transportista=rut_transportista).values())
            if len(transportistas) > 0:
                transporista = transportistas[0]
                datos={'message':'Success','Transportista':transporista}
            else:
                datos={'message':'Error: Transportista NO Encontrado'}
            return JsonResponse(datos)
        else:
            transportistas = list(Transportista.objects.values())
            if len(transportistas)>0:
                datos={'message':'Success','Transportistas':transportistas}
            else:
                datos={'message':'Error: Transportistas NO Encontrados'}
            return JsonResponse(datos)
    
    def post(self,request):
        jd = json.loads(request.body)
        agregar_transportista(rut_transportista=jd['rut_transportista'],nombre_transportista=jd['nombre_transportista'],direccion_transportista=jd['direccion_transportista'],telefono_transportista=jd['telefono_transportista'],correo_transportista=jd['correo_transportista'],contrasena_transportista=jd['contrasena_transportista'],cargo_id_cargo=jd['cargo_id_cargo'],)
        datos={'message':'Success'}
        return JsonResponse(datos)
    
    def put(self,request,rut_transportista):
        jd = json.loads(request.body)
        transportistas = list(Transportista.objects.filter(rut_transportista=rut_transportista).values())
        if len(transportistas)>0:
            modificar_transportista(rut_transportista=jd['rut_transportista'],nombre_transportista=jd['nombre_transportista'],direccion_transportista=jd['direccion_transportista'],telefono_transportista=jd['telefono_transportista'],correo_transportista=jd['correo_transportista'],contrasena_transportista=jd['contrasena_transportista'],cargo_id_cargo=['cargo_id_cargo'])
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: Transportista NO fue posible actualizar sus datos'}
        return JsonResponse(datos)
    
    def delete(self,request,rut_transportista):
        transportistas = list(Transportista.objects.filter(rut_transportista=rut_transportista).values())
        if len(transportistas) > 0:
            eliminar_transportista(rut_transportista)
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: NO fue posible eliminar al Transportista'}
        return JsonResponse(datos)

