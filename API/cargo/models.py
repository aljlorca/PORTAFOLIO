from django.db import models

# Create your models here.
# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models ,connection


class Cargo(models.Model):
    id_cargo = models.BigAutoField(primary_key=True)
    nombre_cargo = models.CharField(max_length=50)
    estado_fila = models.CharField(max_length=1)

    class Meta:
        managed = False
        db_table = 'cargo'
        
    def __str__(self):
        return self.nombre_cargo