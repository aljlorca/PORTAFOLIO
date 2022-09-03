from rest_framework import serializers
from .models import ClienteExterno


class ClienteExternoSerializer(serializers.ModelSerializer):
    class Meta:
        model = ClienteExterno
        fields = '__all__'