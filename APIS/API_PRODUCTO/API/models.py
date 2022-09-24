from django.db import models

# Create your models here.


class Cargo(models.Model):
    id = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'cargo'

class Proveedor(models.Model):
    rut_proveedor = models.BigIntegerField(primary_key=True)
    nombre_proveedor = models.CharField(max_length=150)
    direccion_proveedor = models.CharField(max_length=150)
    telefono_proveedor = models.BigIntegerField()
    correo_proveedor = models.CharField(max_length=150)
    contrasena_proveedor = models.CharField(max_length=120)
    cargo_id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='cargo_id_cargo', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'proveedor'




class Producto(models.Model):
    id_producto = models.BigAutoField(primary_key=True)
    nombre_producto = models.CharField(max_length=150)
    cantidad_producto = models.BigIntegerField()
    rut_proveedor = models.ForeignKey('Proveedor', models.DO_NOTHING, db_column='rut_proveedor')

    class Meta:
        managed = False
        db_table = 'producto'