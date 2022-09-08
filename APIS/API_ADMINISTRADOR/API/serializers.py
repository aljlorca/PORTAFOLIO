from rest_framework import serializers
from .models import Administrador

class AdministradorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Administrador
        fields = '__all__'

'''
class AdministradorAuthSerializer(serializers.ModelSerializer):
    class Meta:
        model = Administrador
        fields = ['rut_administrador', 'contrasena_administrador']
'''