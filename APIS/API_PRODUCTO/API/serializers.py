from rest_framework import serializers
from .models import Producto

class ProductoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Producto
        fields = ['id_producto','nombre_producto','cantidad_prioducto','id_empresa','imagen_producto']



class ProductoHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Producto
        fields = '__all__'