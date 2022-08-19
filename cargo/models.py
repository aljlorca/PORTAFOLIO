from django.db import models

# Create your models here.

class cargo(models.Model):
    nombre = models.CharField(max_length=20)
    descripcion = models.TextField()
    
    def __str__(self):
        return self.nombre