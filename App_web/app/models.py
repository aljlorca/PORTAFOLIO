from django.db import models
from django.conf import settings
# Create your models here.


class Producto(models.Model):
    id_producto = models.CharField(primary_key=True, max_length=120)
    imagen_producto = models.ImageField(max_length=150, blank=True, null=True, upload_to='productos')

    def __str__(self):
        return f'{self.imagen_producto}'