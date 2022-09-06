from rest_framework import serializers
from .models import Proveedor

class ProveedorSerializers(serializers.ModelSerializer):
    class Meta:
        model = Proveedor
        fields = '__all__'
