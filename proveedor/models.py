from django.db import models

# Create your models here.
class proveedor(models.Model):
    rut = models.IntegerField()
    nombre = models.TextField()
    telefono = models.IntegerField()
    rubro = models.TextField()

    def __str__(self):
        return self.nombre      
