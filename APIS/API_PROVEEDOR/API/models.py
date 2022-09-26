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