from django.db import models

# Create your models here.

class Pais(models.Model):
    id_pais = models.BigAutoField(primary_key=True)
    nombre_pais = models.CharField(max_length=50)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'pais'

    def __str__(self):
        return self.nombre_pais