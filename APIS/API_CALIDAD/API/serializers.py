from rest_framework import serializers
from .models import Calidad

class CalidadSerializer(serializers.ModelSerializer):

    class Meta:
        model = Calidad
        fields = ['id_Calidad','descripcion_calidad']
    order_by = (
        ('id_Calidad',))




class CalidadHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Calidad
        fields = '__all__'