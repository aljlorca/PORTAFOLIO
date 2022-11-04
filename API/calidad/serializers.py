from rest_framework import serializers
from .models import Calidad

class CalidadSerializer(serializers.ModelSerializer):

    class Meta:
        model = Calidad
        fields = '__all__'
    order_by = (
        ('id_Calidad',))

