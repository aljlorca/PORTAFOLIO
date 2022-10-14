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
    duns_empresa = models.CharField(max_length=9)
    razon_social_empresa = models.CharField(max_length=70)
    direccion_empresa = models.CharField(max_length=150)
    giro_empresa = models.CharField(max_length=150)
    id_tipo_empresa = models.ForeignKey('TipoEmpresa', models.DO_NOTHING, db_column='id_tipo_empresa')
    id_ciudad = models.ForeignKey(Ciudad, models.DO_NOTHING, db_column='id_ciudad')
    estado_fila = models.CharField(max_length=1)
    id_region = models.ForeignKey('Region', models.DO_NOTHING, db_column='id_region')
    id_pais = models.ForeignKey('Pais', models.DO_NOTHING, db_column='id_pais')

    class Meta:
        managed = False
        db_table = 'empresa'
        unique_together = (('duns_empresa'),)

class Contrato(models.Model):
    id_contrato = models.BigIntegerField(primary_key=True)
    documento_contrato = models.CharField(max_length=125)
    fecha_contrato = models.DateField()
    tipo_contrato = models.CharField(max_length=50)
    id_empresa = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='id_empresa')
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'contrato'