from rest_framework import serializers
from .models import Usuario,Cargo


class CargoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Cargo
        fields = '__all__'

class UsuarioSerializer(serializers.ModelSerializer):
    
    class Meta:
        model = Usuario
        fields = ['id_usuario','numero_identificacion_usuario','nombre_usuario','direccion_usuario','telefono_usuario','correo_usuario','contrasena_usuario','fecha_creacion_usuario','id_cargo','id_empresa','id_ciudad','id_region','id_pais']



class UsuarioHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Usuario
        fields = '__all__'