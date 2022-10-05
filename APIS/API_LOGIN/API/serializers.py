from rest_framework import serializers
from .models import Usuario


class UsuarioSerializer(serializers.ModelSerializer):
    class Meta:
        model = Usuario
        fields = ['id_usuario','numero_identificacion_usuario','nombre_usuario','direccion_usuario','telefono_usuario','correo_usuario','fecha_creacion_usuario','fecha_sesion_usuario','administrador_usuario','id_cargo','id_empresa','id_ciudad',]


class UsuarioHistoricoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Usuario
        fields = '__all__'



class UsuarioDesktopAuthSerializer(serializers.ModelSerializer):
    class Meta:
        model = Usuario
        fields = ['correo_usuario','contrasena_usuario','administrador_usuario']