from django.db import models

# Create your models here.


class Calidad(models.Model):
    id_calidad = models.BigIntegerField(primary_key=True)
    descripcion_calidad = models.CharField(max_length=150)
    estado_fila = models.CharField(max_length=1)
    class Meta:
        managed = False
        db_table = 'calidad'