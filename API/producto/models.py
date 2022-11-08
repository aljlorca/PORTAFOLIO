from django.db import models

# Create your models here.
class TipoEmpresa(models.Model):
    id_tipo_empresa = models.BigIntegerField(primary_key=True)
    tipo_empresa = models.CharField(max_length=150)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'tipo_empresa'

class Empresa(models.Model):
    id_empresa = models.BigIntegerField(primary_key=True)
    duns_empresa = models.CharField(max_length=9)
    razon_social_empresa = models.CharField(max_length=70)
    direccion_empresa = models.CharField(max_length=150)
    id_tipo_empresa = models.ForeignKey('TipoEmpresa', models.DO_NOTHING, db_column='id_tipo_empresa')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'empresa'
        unique_together = (('duns_empresa', 'razon_social_empresa'),)

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

    class Meta:
        managed = False
        db_table = 'usuario'
        unique_together = (('numero_identificacion_usuario', 'telefono_usuario', 'correo_usuario'),)

class Calidad(models.Model):
    id_calidad = models.BigIntegerField(primary_key=True)
    descripcion_calidad = models.CharField(max_length=150)

    class Meta:
        managed = False
        db_table = 'calidad'

class Producto(models.Model):
    id_producto = models.CharField(primary_key=True, max_length=150)
    nombre_producto = models.CharField(max_length=150)
    cantidad_producto = models.CharField(max_length=25)
    precio_producto = models.BigIntegerField()
    imagen_producto = models.ImageField(max_length=150, blank=True, null=True, upload_to='productos')
    id_calidad = models.ForeignKey(Calidad, models.DO_NOTHING, db_column='id_calidad')
    saldo_producto = models.CharField(max_length=1)
    estado_fila = models.CharField(max_length=1)
    id_usuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='id_usuario')
    descripcion_producto = models.CharField(max_length=500)

    class Meta:
        managed = False
        db_table = 'producto'