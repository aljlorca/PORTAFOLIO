from rest_framework import serializers
from .models import Factura

class FacturaSerializer(serializers.ModelSerializer):
    
    class Meta:
        model = Factura
        fields = ['id_factura','fecha_factura','monto_factura','id_venta','id_usuario']

class FacturaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Factura
        fields = '__all__'

