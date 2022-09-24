from django.db import models

# Create your models here.

class Cargo(models.Model):
    id = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'cargo'


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


class ClienteExterno(models.Model):
    rut_cliente_externo = models.BigIntegerField(primary_key=True)
    nombre_cliente_externo = models.CharField(max_length=120)
    direccion_cliente_externo = models.CharField(max_length=120)
    telefono_cliente_externo = models.BigIntegerField()
    correo_cliente_externo = models.CharField(max_length=120)
    contrasena_cliente_externo = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'cliente_externo'

class Contrato(models.Model):
    id_contrato = models.BigAutoField(primary_key=True)
    documento_contrato = models.FileField() # This field type is a guess.
    fecha_contrato = models.DateField()
    rut_cliente_externo = models.ForeignKey('ClienteExterno', models.DO_NOTHING, db_column='rut_cliente_externo')
    rut_administrador = models.ForeignKey('Administrador', models.DO_NOTHING, db_column='rut_administrador')
    tipo_contrato = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'contrato'