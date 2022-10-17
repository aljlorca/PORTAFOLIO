from django.db import models

# Create your models here.


class Producto(models.Model):
    id_producto = models.CharField(primary_key=True, max_length=120)
    imagen_producto = models.ImageField(max_length=150, blank=True, null=True, upload_to='productos')

    def __str__(self):
        return self.imagen_producto