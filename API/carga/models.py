from django.db import models

# Create your models here.
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

class Venta(models.Model):
    id_venta = models.BigIntegerField(primary_key=True)
    descripcion_venta = models.CharField(max_length=500)
    estado_venta = models.CharField(max_length=50)
    monto_bruto_venta = models.BigIntegerField()
    iva = models.CharField(max_length=4)
    monto_neto_venta = models.BigIntegerField()
    fecha_venta = models.DateField()
    tipo_venta = models.CharField(max_length=1)
    id_usuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='id_usuario')
    cantidad_venta = models.FloatField()
    monto_transporte = models.BigIntegerField(blank=True, null=True)
    monto_aduanas = models.BigIntegerField(blank=True, null=True)
    pago_servicio = models.BigIntegerField(blank=True, null=True)
    comision_venta = models.BigIntegerField(blank=True, null=True)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'venta'

class Subasta(models.Model):
    id_subasta = models.BigIntegerField(primary_key=True)
    monto_subasta = models.BigIntegerField()
    id_venta = models.ForeignKey('Venta', models.DO_NOTHING, db_column='id_venta')
    fecha_subasta = models.DateField()
    estado_fila = models.CharField(max_length=1)
    id_usuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='id_usuario')

    class Meta:
        managed = False
        db_table = 'subasta'

class Carga(models.Model):
    id_carga = models.BigIntegerField(primary_key=True)
    capacidad_carga = models.CharField(max_length=300)
    refrigeracion_carga = models.CharField(max_length=1)
    tamano_carga = models.CharField(max_length=150)
    id_subasta = models.ForeignKey('Subasta', models.DO_NOTHING, db_column='id_subasta')
    id_usuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='id_usuario')
    estado_fila = models.CharField(max_length=1)
    class Meta:
        managed = False
        db_table = 'carga'
