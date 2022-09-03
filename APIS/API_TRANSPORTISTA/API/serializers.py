from rest_framework import serializers
from .models import Transportista

class TransportistaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Transportista
        fields = '__all__'