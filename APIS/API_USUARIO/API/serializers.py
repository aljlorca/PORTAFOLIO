from rest_framework import serializers
from .models import Usuario

class UsuarioSerializer(serializers.ModelSerializer):
    class Meta:
        model = Usuario
        fields = ['numero_identificacion_usuario','nombre_usuario','direccion_usuario','telefono_usuario','correo_usuario','id_cargo','id_empresa','id_ciudad']



class UsuarioHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Usuario
        fields = '__all__'