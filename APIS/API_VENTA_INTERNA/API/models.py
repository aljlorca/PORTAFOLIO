from django.db import models

# Create your models here.

class Cargo(models.Model):
    id_cargo = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'cargo'
        
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
    id_pais = models.ForeignKey('Pais', models.DO_NOTHING, db_column='id_pais')
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

class TipoEmpresa(models.Model):
    id_tipo_empresa = models.BigIntegerField(primary_key=True)
    tipo_empresa = models.CharField(max_length=150)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'tipo_empresa'

class Empresa(models.Model):
    id_empresa = models.BigIntegerField(primary_key=True)
    rut_empresa = models.CharField(max_length=10, blank=True, null=True)
    duns_empresa = models.CharField(max_length=9, blank=True, null=True)
    razon_social_empresa = models.CharField(max_length=70)
    direccion_empresa = models.CharField(max_length=150)
    giro_empresa = models.CharField(max_length=150)
    id_tipo_empresa = models.ForeignKey('TipoEmpresa', models.DO_NOTHING, db_column='id_tipo_empresa')
    id_ciudad = models.ForeignKey('Ciudad', models.DO_NOTHING, db_column='id_ciudad')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'empresa'
        unique_together = (('rut_empresa', 'duns_empresa'),)

class VentaExterna(models.Model):
    id_venta_externa = models.BigIntegerField(primary_key=True)
    descripcion_venta = models.CharField(max_length=500)
    estado_venta = models.CharField(max_length=50)
    monto_bruto_venta = models.BigIntegerField()
    iva = models.CharField(max_length=4)
    monto_neto_venta = models.BigIntegerField()
    fecha_venta = models.DateField()
    id_empresa = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='id_empresa')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'venta_externa'

class Saldo(models.Model):
    id_saldo = models.BigIntegerField(primary_key=True)
    descripcion_saldo = models.CharField(max_length=500)
    monto_bruto_saldo = models.BigIntegerField()
    iva_saldo = models.CharField(max_length=4)
    monto_neto_saldo = models.BigIntegerField()
    id_venta_externa = models.ForeignKey('VentaExterna', models.DO_NOTHING, db_column='id_venta_externa')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'saldo'  
    
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

    class Meta:
        managed = False
        db_table = 'usuario'
        unique_together = (('numero_identificacion_usuario', 'telefono_usuario', 'correo_usuario'),)

class VentaInterna(models.Model):
    id_venta_interna = models.BigIntegerField(primary_key=True)
    descripcion_venta_interna = models.CharField(max_length=500)
    monto_bruto_venta_interna = models.BigIntegerField()
    iva_venta_interna = models.CharField(max_length=4)
    monto_neto_venta_interna = models.BigIntegerField()
    fecha_venta_interna = models.DateField()
    id_saldo = models.ForeignKey('Saldo', models.DO_NOTHING, db_column='id_saldo')
    id_empresa = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='id_empresa', blank=True, null=True)
    estado_fila = models.CharField(max_length=1)
    id_usuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='id_usuario', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'venta_interna'