from rest_framework import serializers
from .models import Postulacion

class PostulacionSerializer(serializers.ModelSerializer):
    class Meta:
        model = Postulacion
        fields = ['id_postulacion','descripcion','estado','id_venta_externa','id_empresa']



class PostulacionHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Postulacion
        fields = '__all__'