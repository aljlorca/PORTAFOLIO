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
def agregar_usuario(numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,administrador_usuario,id_cargo,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    usuario_vigente = '1'
    fecha_creacion_usuario = datetime.date.today()
    cursor.callproc('USUARIO_AGREGAR',[numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,usuario_vigente,fecha_creacion_usuario,administrador_usuario,id_cargo,id_empresa,salida])
    return round(salida.getvalue())

def modificar_usuario(numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,administrador_usuario,id_cargo,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('USUARIO_MODIFICAR',[numero_identificacion_usuario,nombre_usuario,direccion_usuario,telefono_usuario,correo_usuario,contrasena_usuario,administrador_usuario,id_cargo,id_empresa,salida])
    return round(salida.getvalue())

def eliminar_usuario(id_usuario,correo_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('USUARIO_ELIMINAR',[id_usuario,correo_usuario,salida])
    return round(salida.getvalue())

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
        try:
            jd = json.loads(request.body)
            try:
                salida = agregar_usuario(numero_identificacion_usuario=jd['numero_identificacion_usuario'],nombre_usuario=jd['nombre_usuario'],direccion_usuario=jd['direccion_usuario'],telefono_usuario=jd['telefono_usuario'],correo_usuario=jd['correo_usuario'],contrasena_usuario=jd['contrasena_usuario'],administrador_usuario=jd['administrador_usuario'],id_cargo=jd['id_cargo'],id_empresa=jd['id_empresa'])
                if salida == 1:
                    datos = {'message':'Success'}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible agregar al usuario'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)
        

    def put(self, request,id_usuario):
        try:
            jd = json.loads(request.body)
            usuarios = list(Usuario.objects.filter(id_usuario=id_usuario).values())
            if len(usuarios) > 0:
                try:
                    salida = modificar_usuario(numero_identificacion_usuario=jd['numero_identificacion_usuario'],nombre_usuario=jd['nombre_usuario'],direccion_usuario=jd['direccion_usuario'],telefono_usuario=jd['telefono_usuario'],correo_usuario=jd['correo_usuario'],contrasena_usuario=jd['contrasena_usuario'],administrador_usuario=jd['administrador_usuario'],id_cargo=jd['id_cargo'],id_empresa=jd['id_empresa'])
                    if salida == 1:
                        datos={'message':"Success"}
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posible modificar al usuario'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: No se encuentra el usuario"}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def delete(self, request,id_usuario):
        try:
            usuarios = list(Usuario.objects.filter(id_usuario=id_usuario).values())
            jd = json.loads(request.body)
            if len(usuarios) > 0:
                try:
                    salida = eliminar_usuario(id_usuario,correo_usuario=jd['correo_usuario'])
                    if salida == 1:
                        datos={'message':"Success"}
                    elif salida == 0:
                        datos = {'message':'ERORR: no fue posible elminar el usuario'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: no se encuentra el usuario"}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

class UsuarioViewset(viewsets.ModelViewSet):
    queryset = Usuario.objects.filter(usuario_vigente='1')
    serializer_class = UsuarioSerializer


class UsuarioHistoricoViewset(viewsets.ModelViewSet):
    queryset = Usuario.objects.all()
    serializer_class = UsuarioHistoricoSerializer