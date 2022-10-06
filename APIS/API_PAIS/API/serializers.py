from rest_framework import serializers
from .models import Pais

class PaisSerializer(serializers.ModelSerializer):

    class Meta:
        model = Pais
        fields = ['id_pais','nombre_pais']

class PaisHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Pais
        fields = '__all__'