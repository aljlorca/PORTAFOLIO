from django.db import models

# Create your models here.



class Cargo(models.Model):
    id = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'cargo'


class Administrador(models.Model):
    rut_administrador = models.CharField(primary_key=True,max_length=13)
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
    rut_cliente_externo = models.CharField(primary_key=True,max_length=13)
    nombre_cliente_externo = models.CharField(max_length=120)
    direccion_cliente_externo = models.CharField(max_length=120)
    telefono_cliente_externo = models.BigIntegerField()
    correo_cliente_externo = models.CharField(max_length=120)
    contrasena_cliente_externo = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'cliente_externo'

class ClienteInterno(models.Model):
    rut_cliente_interno = models.CharField(primary_key=True,max_length=13)
    nombre_cliente_interno = models.CharField(max_length=120)
    direccion_cliente_interno = models.CharField(max_length=120)
    telefono_cliente_interno = models.BigIntegerField()
    correo_cliente_interno = models.CharField(max_length=120)
    contrasena_cliente_interno = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'cliente_interno'




class Proveedor(models.Model):
    rut_proveedor = models.CharField(primary_key=True,max_length=13)
    nombre_proveedor = models.CharField(max_length=150)
    direccion_proveedor = models.CharField(max_length=150)
    telefono_proveedor = models.BigIntegerField()
    correo_proveedor = models.CharField(max_length=150)
    contrasena_proveedor = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'proveedor'


class Transportista(models.Model):
    rut_transportista = models.CharField(primary_key=True,max_length=13)
    nombre_transportista = models.CharField(max_length=120)
    direccion_transportista = models.CharField(max_length=120)
    telefono_transportista = models.BigIntegerField()
    correo_transportista = models.CharField(max_length=120)
    contrasena_transportista = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'transportista'