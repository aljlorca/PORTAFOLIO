from rest_framework import serializers
from .models import Contrato



class ContratoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Contrato
        fields = ['id_contrato','documento_contrato','fecha_contrato','tipo_contrato','id_empresa']


class ContratoHistoricoSerializer(serializers.ModelSerializer):
    class Meta:
        model = Contrato
        fields = '__all__'


