from django.db import models

# Create your models here.
class Cargo(models.Model):
    id = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'cargo'
    
    def __str__(self):
        return self.nombre_cargo

class ClienteInterno(models.Model):
    rut_cliente_interno = models.BigIntegerField(primary_key=True)
    nombre_cliente_interno = models.CharField(max_length=120)
    direccion_cliente_interno = models.CharField(max_length=120)
    telefono_cliente_interno = models.BigIntegerField()
    correo_cliente_interno = models.CharField(max_length=120)
    contrasena_cliente_interno = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'cliente_interno'
