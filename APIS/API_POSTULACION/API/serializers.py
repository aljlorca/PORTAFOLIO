from rest_framework import serializers
from .models import Postulacion

class PostulacionSerializer(serializers.ModelSerializer):
    class Meta:
        model = Postulacion
        fields = ['id_postulacion','descripcion_postulacion','estado_postulacion','id_venta','id_usuario','id_producto']



class PostulacionHistoricoSerializer(serializers.ModelSerializer):

    class Meta:
        model = Postulacion
        fields = '__all__'