from rest_framework import serializers
from .models import Administrador, Cargo

class AdministradorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Administrador
        fields = '__all__'