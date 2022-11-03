from rest_framework import serializers
from .models import Carga

class CargaSerializer(serializers.ModelSerializer):

    class Meta:
        model = Carga
        fields = '__all__'
    order_by = (
        ('id_Calidad',))
