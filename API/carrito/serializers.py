from rest_framework import serializers
from .models import Carrito

class CarritoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Carrito
        fields = ['id_carrito','fecha_carrito','monto_carrito','id_producto','id_usuario']

class CarritoHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Carrito
        fields = '__all__'