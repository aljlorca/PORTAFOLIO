from rest_framework import serializers
from .models import Empresa

class EmpresaSerializer(serializers.ModelSerializer):
    class Meta:
        model = Empresa
        fields = ['id_empresa','duns_empresa','razon_social_empresa','direccion_empresa','giro_empresa','id_tipo_empresa','id_ciudad','id_region','id_pais']



class EmpresaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Empresa
        fields = '__all__'