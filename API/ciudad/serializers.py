from rest_framework import serializers
from .models import Ciudad

class CiudadSerializer(serializers.ModelSerializer):

    class Meta:
        model = Ciudad
        fields = ['id_ciudad','nombre_ciudad','codigo_postal','id_region']

class CiudadHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Ciudad
        fields = '__all__'