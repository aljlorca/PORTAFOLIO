from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Usuario
from rest_framework import viewsets
from .serializers import UsuarioDesktopAuthSerializer
import cx_Oracle
import json

# Create your views here.
def request_usuario(correo_usuario,contrasena_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('LOGIN', [correo_usuario,contrasena_usuario,out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class ClienteExternoAuthView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)


    def post(self, request):
        jd = json.loads(request.body)
        usuarios = request_usuario(correo_usuario=jd['correo_usuario'],contrasena_usuario=jd['contrasena_usuario'])
        if len(usuarios) > 0:
            usuario = usuarios[0]
            datos={'message':"Success",'usuario':usuario}
        else:
            datos={'message':"ERROR: usuario No Encontrado"}

        return JsonResponse(datos)

class UsuarioHistoricoViewset(viewsets.ModelViewSet):
    queryset = Usuario.objects.filter(administrador_usuario = '1')
    serializer_class = UsuarioDesktopAuthSerializer

