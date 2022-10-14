from rest_framework import serializers
from .models import Reporte

class ReporteSerializer(serializers.ModelSerializer):
    class Meta:
        model = Reporte
        fields = ['id_reporte','descripcion_reporte','productos_entregados_reporte','productos_perdidos_reporte','productos_restantes_reporte','id_venta','id_usuario']

class ReporteHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Reporte
        fields = '__all__'