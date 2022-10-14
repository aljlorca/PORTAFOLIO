from rest_framework import serializers
from .models import Pedido

class PedidoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Pedido
        fields = ['id_pedido','fecha_pedido','id_venta','id_producto']



class PedidoHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Pedido
        fields = '__all__'