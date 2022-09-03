from rest_framework import serializers
from .models import Cargo

class CategoriaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Cargo
        fields = '__all__'