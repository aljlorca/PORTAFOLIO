from rest_framework import serializers
from .models import Empresa

class EmpresaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Empresa
        fields = ['id_empresa','duns_empresa','razon_social_empresa','direccion_empresa','id_tipo_empresa']



class EmpresaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Empresa
        fields = '__all__'