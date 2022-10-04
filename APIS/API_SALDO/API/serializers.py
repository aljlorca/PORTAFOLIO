from rest_framework import serializers
from .models import Saldo

class SaldoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Saldo
        fields = ['id_saldo','descripcion_saldo','monto_bruto_saldo','iva_saldo','monto_neto_saldo','id_venta_externa']



class SaldoHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Saldo
        fields = '__all__'