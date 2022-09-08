import json
from django.shortcuts import render
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from django.db import connection
from .models import Administrador,ClienteExterno,ClienteInterno,Transportista,Proveedor
from .serializers import AdministradorSerializer,ClienteExternoSerializer,ClienteInternoSerializer,ProveedorSerializer,TransportistaSerializer
from rest_framework import viewsets
import cx_Oracle
from django.views.decorators.csrf import csrf_exempt
# Create your views here.

def get_administrador_verificar(rut_administrador,contrasena_administrador):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    respuesta = cursor.var(cx_Oracle.STRING)
    cursor.callproc('ADMINISTRADOR_ELIMINAR',[rut_administrador,contrasena_administrador,respuesta])
    return respuesta.getvalue()


    
class AdministradorViewset(viewsets.ModelViewSet):
    queryset = Administrador.objects.all()
    serializer_class = AdministradorSerializer

class ClienteExternoViewset(viewsets.ModelViewSet):
    queryset = ClienteExterno.objects.all()
    serializer_class = ClienteExternoSerializer

class ClienteInternoViewset(viewsets.ModelViewSet):
    queryset = ClienteInterno.objects.all()
    serializer_class = ClienteInternoSerializer

class ProveedorViewset(viewsets.ModelViewSet):
    queryset = Proveedor.objects.all()
    serializer_class = ProveedorSerializer

class TransportistaViewset(viewsets.ModelViewSet):
    queryset = Transportista.objects.all()
    serializer_class = TransportistaSerializer

