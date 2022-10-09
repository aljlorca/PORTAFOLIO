from rest_framework import serializers
from .models import Usuario,Cargo


class CargoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Cargo
        fields = '__all__'

class UsuarioSerializer(serializers.ModelSerializer):
    
    nombre_cargo = serializers.CharField(read_only=True,source='cargo.nombre')
    cargo = CargoSerializer(read_only=True)
    class Meta:
        model = Usuario
        fields = ['id_usuario','numero_identificacion_usuario','nombre_usuario','direccion_usuario','telefono_usuario','correo_usuario','id_cargo','id_empresa','id_ciudad','nombre_cargo','cargo']



class UsuarioHistoricoSerializer(serializers.ModelSerializer):
    nombre_cargo = serializers.CharField(read_only=True,source='cargo.nombre')
    cargo = CargoSerializer(read_only=True)
    class Meta:
        model = Usuario
        fields = '__all__'