from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Proveedor
import json

# Create your views here.
def agregar_proveedor(rut_proveedor,nombre_proveedor,direccion_proveedor,telefono_proveedor,correo_proveedor,contrasena_proveedor,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('PROVEEDOR_AGREGAR',[rut_proveedor,nombre_proveedor,direccion_proveedor,telefono_proveedor,correo_proveedor,contrasena_proveedor,cargo_id_cargo])

def modificar_proveedor(rut_proveedor,nombre_proveedor,direccion_proveedor,telefono_proveedor,correo_proveedor,contrasena_proveedor,cargo_id_cargo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('PROVEEDOR_MODIFICAR',[rut_proveedor,nombre_proveedor,direccion_proveedor,telefono_proveedor,correo_proveedor,contrasena_proveedor,cargo_id_cargo])

def eliminar_proveedor(rut_proveedor):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('PROVEEDOR_ELIMINAR',[rut_proveedor])

def listar_proveedor():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('PROVEEDOR_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

class ProveedorView(View):

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,rut_proveedor=0):
        if(rut_proveedor>0):
            proveedores=list(Proveedor.objects.filter(rut_proveedor=rut_proveedor).values())
            if len(proveedores) > 0:
                proveedor = proveedores[0]
                datos={'message':'Success','Proveedor':proveedor}
            else:
                datos={'message':'Error: Proveedor NO Encontrado'}
            return JsonResponse(datos)
        else:
            proveedores = list(Proveedor.objects.values())
            if len(proveedores)>0:
                datos={'message':'Success','Proveedores':proveedores}
            else:
                datos={'message':'Error: Proveedores NO Encontrados'}
            return JsonResponse(datos)


    def post(self,request):
        jd = json.loads(request.body)
        agregar_proveedor(rut_proveedor=jd['rut_proveedor'],nombre_proveedor=jd['nombre_proveedor'],direccion_proveedor=jd['direccion_proveedor'],telefono_proveedor=jd['telefono_proveedor'],correo_proveedor=jd['correo_proveedor'],contrasena_proveedor=jd['contrasena_proveedor'],cargo_id_cargo=jd['cargo_id_cargo'])
        datos={'message':'Success'}
        return JsonResponse(datos)

    def put(self,request,rut_proveedor):
        jd = json.loads(request.body)
        proveedores = list(Proveedor.objects.filter(rut_proveedor=rut_proveedor).values())
        if len(proveedores) > 0:
            modificar_proveedor(rut_proveedor=jd['rut_proveedor'],nombre_proveedor=jd['nombre_proveedor'],direccion_proveedor=jd['direccion_proveedor'],telefono_proveedor=jd['telefono_proveedor'],correo_proveedor=jd['correo_proveedor'],contrasena_proveedor=jd['contrasena_proveedor'],cargo_id_cargo=jd['cargo_id_cargo'])
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: Proveedor no se pudo actualizar'}
        return JsonResponse(datos)
    
    def delete(self,request,rut_proveedor):
        proveedores = list(Proveedor.objects.filter(rut_proveedor=rut_proveedor).values())
        if len(proveedores) > 0:
            eliminar_proveedor(rut_proveedor)
            datos={'message':'Succes'}
        else:
            datos={'message':'ERROR: Proveedor no pudo ser eliminado'}
        return JsonResponse(datos)