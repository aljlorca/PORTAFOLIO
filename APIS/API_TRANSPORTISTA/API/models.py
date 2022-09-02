from django.db import models

# Create your models here.

class Cargo(models.Model):
    id = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'cargo'

class Transportista(models.Model):
    rut_transportista = models.BigIntegerField(primary_key=True)
    nombre_transportista = models.CharField(max_length=120)
    direccion_transportista = models.CharField(max_length=120)
    telefono_transportista = models.BigIntegerField()
    correo_transportista = models.CharField(max_length=120)
    contrasena_transportista = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'transportista'
