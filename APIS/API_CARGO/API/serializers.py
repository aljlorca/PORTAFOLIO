from rest_framework import serializers
from .models import Cargo

class CargoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Cargo
        fields = ['id_cargo','nombre_cargo']
        order_by = (
        ('id_cargo',))




class CargoHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Cargo
        fields = '__all__'