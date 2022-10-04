from rest_framework import serializers
from .models import ResumenVenta

class ResumenVentaSerializer(serializers.ModelSerializer):
    class Meta:
        model = ResumenVenta
        fields = ['id_resumen','monto_neto_venta','descripcion_resumen','id_venta_externa']



class ResumenVentaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = ResumenVenta
        fields = '__all__'