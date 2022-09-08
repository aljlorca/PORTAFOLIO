from rest_framework import serializers
from .models import Administrador, ClienteExterno,ClienteInterno,Proveedor,Transportista


class AdministradorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Administrador
        fields = ['rut_administrador', 'contrasena_administrador']

class ClienteExternoSerializer(serializers.ModelSerializer):
    class Meta:
        model = ClienteExterno
        fields = ['rut_cliente_externo', 'contrasena_cliente_externo']

class ClienteInternoSerializer(serializers.ModelSerializer):
    class Meta:
        model = ClienteInterno
        fields = ['rut_cliente_interno', 'contrasena_cliente_interno']

class ProveedorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Proveedor
        fields = ['rut_proveedor', 'contrasena_proveedor']


class TransportistaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Transportista
        fields = ['rut_transportista', 'contrasena_transportista']

