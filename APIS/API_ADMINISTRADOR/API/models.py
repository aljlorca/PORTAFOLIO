from django.db import models

# Create your models here.

class Administrador(models.Model):
    rut_administrador = models.BigIntegerField(primary_key=True)
    nombre_administrador = models.CharField(max_length=150)
    direccion_administrador = models.CharField(max_length=150)
    telefono_administrador = models.BigIntegerField()
    correo_administrador = models.CharField(max_length=150)
    contrasena_administrador = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'administrador'
