from rest_framework import serializers
from .models import Administrador, ClienteExterno,ClienteInterno,Proveedor,Transportista
from rest_framework.authtoken.models import Token

class AdministradorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Administrador
        fields = ['rut_administrador', 'contrasena_administrador']
        extra_kwargs = {'contrasena_administrador': {'write_only': True, 'required': True}}
    
    def create(self, validated_data):
        user = Administrador.objects.create_user(**validated_data)
        Token.objects.create(Administrador=Administrador)
        return Administrador


class ClienteExternoSerializer(serializers.ModelSerializer):
    class Meta:
        model = ClienteExterno
        fields = ['rut_cliente_externo', 'contrasena_cliente_externo']
        extra_kwargs = {'contrasena_cliente_externo': {'write_only': True, 'required': True}}

class ClienteInternoSerializer(serializers.ModelSerializer):
    class Meta:
        model = ClienteInterno
        fields = ['rut_cliente_interno', 'contrasena_cliente_interno']
        extra_kwargs = {'contrasena_cliente_interno': {'write_only': True, 'required': True}}

class ProveedorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Proveedor
        fields = ['rut_proveedor', 'contrasena_proveedor']
        extra_kwargs = {'contrasena_proveedor': {'write_only': True, 'required': True}}


class TransportistaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Transportista
        fields = ['rut_transportista', 'contrasena_transportista']
        extra_kwargs = {'contrasena_transportista': {'write_only': True, 'required': True}}

