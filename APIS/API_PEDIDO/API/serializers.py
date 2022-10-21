from rest_framework import serializers
from .models import Pedido

class PedidoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Pedido
        fields = ['id_pedido','descripcion_pedido','fecha_sla_pedido','id_usuario']


class PedidoHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Pedido
        fields = '__all__'