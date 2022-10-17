from rest_framework import serializers
from .models import Subasta

class SubastaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Subasta
        fields = ['id_subasta','monto_subasta','id_venta','fecha_subasta','id_usuario']



class SubastaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Subasta
        fields = '__all__'