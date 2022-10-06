from rest_framework import serializers
from .models import Region

class RegionSerializer(serializers.ModelSerializer):

    class Meta:
        model = Region
        fields = ['id_region','nombre_region','id_pais']

class RegionHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Region
        fields = '__all__'