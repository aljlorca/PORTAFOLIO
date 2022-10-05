from rest_framework import serializers
from .models import VentaInterna

class VentaInternaSerializer(serializers.ModelSerializer):
    class Meta:
        model = VentaInterna
        fields = ['id_venta_interna','descripcion_venta_interna','monto_bruto_venta_interna','iva_venta_interna','monto_neto_venta_interna','fecha_venta_interna','id_saldo','id_empresa','id_usuario']



class VentaInternaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = VentaInterna
        fields = '__all__'