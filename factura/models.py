from django.db import models
from core.models import producto
from usuario.models import Usuario
from datetime import datetime
# Create your models here.

class factura(models.Model): 
    usuario = models.ForeignKey(Usuario, on_delete=models.CASCADE)
    fecha = models.DateField(default=datetime.now)
    iva = models.IntegerField(default=19)
    total = models.IntegerField()
#tipo especifica si es boleta o factura (false = boleta)
    def __str__(self):
        return str(self.id)

    class Meta:
        verbose_name = 'Venta'
        verbose_name_plural = 'Ventas'
        ordering = ['id']