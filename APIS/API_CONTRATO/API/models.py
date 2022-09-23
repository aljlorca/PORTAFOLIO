from django.db import models

# Create your models here.
class Contrato(models.Model):
    id_contrato = models.BigAutoField(primary_key=True)
    documento_contrato = models.TextField()  # This field type is a guess.
    fecha_contrato = models.DateField()
    cliente_externo_rut_cliente_externo = models.ForeignKey('ClienteExterno', models.DO_NOTHING, db_column='cliente_externo_rut_cliente_externo')
    administrador_rut_administrador = models.ForeignKey('Administrador', models.DO_NOTHING, db_column='administrador_rut_administrador')
    tipo_contrato = models.CharField(max_length=50)

    class Meta:
        managed = False
        db_table = 'contrato'