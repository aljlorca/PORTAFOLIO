from rest_framework import serializers
from .models import TipoEmpresa

class TipoEmpresaSerializer(serializers.ModelSerializer):
    class Meta:
        model = TipoEmpresa
        fields = ['id_tipo_empresa','tipo_empresa']



class TipoEmpresaHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = TipoEmpresa
        fields = '__all__'