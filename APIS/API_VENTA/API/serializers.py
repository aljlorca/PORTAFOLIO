from rest_framework import serializers
from .models import Venta

class VentaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Venta
        fields = ['id_venta','descripcion_venta','estado_venta','monto_bruto_venta','iva','monto_neto_venta','fecha_venta','tipo_venta','id_usuario','cantidad_venta','monto_transporte','monto_aduanas','pago_servicio','comision_venta']



class VentaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Venta
        fields = '__all__'