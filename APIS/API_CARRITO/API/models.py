from django.db import models

# Create your models here.
class Pais(models.Model):
    id_pais = models.BigIntegerField(primary_key=True)
    nombre_pais = models.CharField(max_length=50)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'pais'

class Region(models.Model):
    id_region = models.BigIntegerField(primary_key=True)
    nombre_region = models.CharField(max_length=150)
    id_pais = models.ForeignKey(Pais, models.DO_NOTHING, db_column='id_pais')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'region'

class Ciudad(models.Model):
    id_ciudad = models.BigIntegerField(primary_key=True)
    nombre_ciudad = models.CharField(max_length=150)
    codigo_postal = models.CharField(max_length=50)
    id_region = models.ForeignKey('Region', models.DO_NOTHING, db_column='id_region')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'ciudad'

class Empresa(models.Model):
    id_empresa = models.BigIntegerField(primary_key=True)
    duns_empresa = models.CharField(unique=True, max_length=9)
    razon_social_empresa = models.CharField(max_length=70)
    direccion_empresa = models.CharField(max_length=150)
    giro_empresa = models.CharField(max_length=150)
    id_tipo_empresa = models.ForeignKey('TipoEmpresa', models.DO_NOTHING, db_column='id_tipo_empresa')
    id_ciudad = models.ForeignKey('Ciudad', models.DO_NOTHING, db_column='id_ciudad')
    estado_fila = models.CharField(max_length=1)
    id_region = models.ForeignKey('Region', models.DO_NOTHING, db_column='id_region')
    id_pais = models.ForeignKey('Pais', models.DO_NOTHING, db_column='id_pais')

    class Meta:
        managed = False
        db_table = 'empresa'

class Cargo(models.Model):
    id_cargo = models.BigIntegerField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'cargo'

class Usuario(models.Model):
    id_usuario = models.BigIntegerField(primary_key=True)
    numero_identificacion_usuario = models.CharField(max_length=20)
    nombre_usuario = models.CharField(max_length=150)
    direccion_usuario = models.CharField(max_length=150)
    telefono_usuario = models.CharField(max_length=20)
    correo_usuario = models.CharField(max_length=150)
    contrasena_usuario = models.CharField(max_length=64)
    usuario_vigente = models.CharField(max_length=1)
    fecha_creacion_usuario = models.DateField()
    fecha_sesion_usuario = models.DateField(blank=True, null=True)
    administrador_usuario = models.CharField(max_length=1)
    id_cargo = models.ForeignKey('Cargo', models.DO_NOTHING, db_column='id_cargo')
    id_empresa = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='id_empresa', blank=True, null=True)
    id_ciudad = models.ForeignKey('Ciudad', models.DO_NOTHING, db_column='id_ciudad')
    id_region = models.ForeignKey('Region', models.DO_NOTHING, db_column='id_region')
    id_pais = models.ForeignKey('Pais', models.DO_NOTHING, db_column='id_pais')

    class Meta:
        managed = False
        db_table = 'usuario'
        unique_together = (('numero_identificacion_usuario', 'telefono_usuario', 'correo_usuario'),)


class Calidad(models.Model):
    id_calidad = models.BigIntegerField(primary_key=True)
    descripcion_calidad = models.CharField(max_length=150)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'calidad'

class Producto(models.Model):
    id_producto = models.CharField(primary_key=True, max_length=150)
    nombre_producto = models.CharField(max_length=150)
    cantidad_producto = models.FloatField()
    precio_producto = models.BigIntegerField()
    imagen_producto = models.ImageField(max_length=150, blank=True, null=True)
    id_calidad = models.ForeignKey('Calidad', models.DO_NOTHING, db_column='id_calidad')
    saldo_producto = models.CharField(max_length=1)
    estado_fila = models.CharField(max_length=1)
    id_usuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='id_usuario')

    class Meta:
        managed = False
        db_table = 'producto'


class Carrito(models.Model):
    id_carrito = models.BigIntegerField(primary_key=True)
    fecha_carrito = models.DateField()
    monto_carrito = models.BigIntegerField()
    id_producto = models.ForeignKey('Producto', models.DO_NOTHING, db_column='id_producto', blank=True, null=True)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'carrito'