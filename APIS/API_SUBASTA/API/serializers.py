from rest_framework import serializers
from .models import Subasta

class SubastaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Subasta
        fields = ['id_subasta_transportista','monto','id_venta_externa','id_empresa','fecha_subasta']



class SubastaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Subasta
        fields = '__all__'