from rest_framework import serializers
from .models import VentaExterna

class VentaExternaSerializer(serializers.ModelSerializer):
    class Meta:
        model = VentaExterna
        fields = ['id_venta_externa','descripcion_venta','estado_venta','monto_bruto_venta','iva','monto_neto_venta','fecha_venta','id_empresa']



class VentaExternaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = VentaExterna
        fields = '__all__'