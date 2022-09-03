from rest_framework import serializers
from .models import ClienteInterno

class ClienteInternoSerializer(serializers.ModelSerializer):
    class Meta:
        model = ClienteInterno
        fields = '__all__'