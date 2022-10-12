from rest_framework import serializers
from .models import Producto

class ProductoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Producto
        fields = '__all__'

class ProductoHistoricoSerializer(serializers.ModelSerializer):
    class Meta:
        Model = Producto
        fields = '__all__'