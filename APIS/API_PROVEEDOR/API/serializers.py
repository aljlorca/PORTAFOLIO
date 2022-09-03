from rest_framework import serializers
from .models import Proveedor

class ProveedorSerializers(serializers.ModelSerializer):
    class Meta:
        model = Proveedor
        flieds = '__all__'
