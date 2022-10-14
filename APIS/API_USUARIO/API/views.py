from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Usuario
from .serializers import UsuarioSerializer,UsuarioHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
import datetime

# Create your views here.
def agregar_usuario(numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,administrador_usuario,id_cargo,id_empresa,id_ciudad,id_region,id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    usuario_vigente = '1'
    fecha_creacion_usuario = datetime.date.today()
    cursor.callproc('USUARIO_AGREGAR',[numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,usuario_vigente,fecha_creacion_usuario,administrador_usuario,id_cargo,id_empresa,id_ciudad,id_region,id_pais,salida])
    return salida

def modificar_usuario(numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,administrador_usuario,id_cargo,id_empresa,id_ciudad,id_region,id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('USUARIO_MODIFICAR',[numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,administrador_usuario,id_cargo,id_empresa,id_ciudad,id_region,id_pais,salida])

def eliminar_usuario(correo_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('USUARIO_ELIMINAR',[correo_usuario,salida])

def lista_usuario():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('USUARIO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class UsuarioView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_usuario=0):
        if(id_usuario > 0):
            usuarios=list(Usuario.objects.filter(id_usuario=id_usuario).values())
            if len(usuarios) > 0:
                usuario = usuarios[0]
                datos={'message':"Success","usuario":usuario}
            else:
                datos={'message':"ERROR: Cargo No Encontrado"}
            return JsonResponse(datos)
        else:
            usuarios = list(Usuario.objects.values())
            if len(usuarios) > 0:
                datos={'message':"Success","usuarios":usuarios}
            else:
                datos={'message':"ERROR: usuarios No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_usuario(numero_identificacion_usuario=jd['numero_identificacion_usuario'],nombre_usuario=jd['nombre_usuario'],direccion_usuario=jd['direccion_usuario'],telefono_usuario=jd['telefono_usuario'],correo_usuario=jd['correo_usuario'],contrasena_usuario=jd['contrasena_usuario'],administrador_usuario=jd['administrador_usuario'],id_cargo=jd['id_cargo'],id_empresa=jd['id_empresa'],id_ciudad=jd['id_ciudad'],id_region=jd['id_region'],id_pais=jd['id_pais'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_usuario):
        jd = json.loads(request.body)
        usuarios = list(Usuario.objects.filter(id_usuario=id_usuario).values())
        if len(usuarios) > 0:
            modificar_usuario(numero_identificacion_usuario=jd['numero_identificacion_usuario'],nombre_usuario=jd['nombre_usuario'],direccion_usuario=jd['direccion_usuario'],telefono_usuario=jd['telefono_usuario'],correo_usuario=jd['correo_usuario'],contrasena_usuario=jd['contrasena_usuario'],administrador_usuario=jd['administrador_usuario'],id_cargo=jd['id_cargo'],id_empresa=jd['id_empresa'],id_ciudad=jd['id_ciudad'],id_region=jd['id_region'],id_pais=jd['id_pais'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el usuario"}
        return JsonResponse(datos)

    def delete(self, request,id_usuario):
        usuarios = list(Usuario.objects.filter(id_usuario=id_usuario).values())
        jd = json.loads(request.body)
        if len(usuarios) > 0:
            eliminar_usuario(correo_usuario=jd['correo_usuario'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el cargo"}
        return JsonResponse(datos)

class UsuarioViewset(viewsets.ModelViewSet):
    queryset = Usuario.objects.filter(usuario_vigente='1')
    serializer_class = UsuarioSerializer


class UsuarioHistoricoViewset(viewsets.ModelViewSet):
    queryset = Usuario.objects.all()
    serializer_class = UsuarioHistoricoSerializer