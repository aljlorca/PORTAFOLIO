from django.db import models
from django.db.models.base import ModelState
from django.db.models.expressions import Case
from django.db.models.fields import BooleanField, CharField, NullBooleanField
from datetime import date,datetime
from proveedor.models import proveedor

#Create your models here
class familia(models.Model):
    nombre = models.CharField(max_length=50)

    def __str__(self):
        return self.nombre


class producto(models.Model):
    id = models.CharField(max_length=17, primary_key=True)
    nombre = models.CharField(max_length=30)
    descripcion = models.TextField(max_length=300)
    precio = models.IntegerField() 
    familia = models.ForeignKey(familia, on_delete=models.PROTECT)
    vencimiento = models.DateField()
    stock = models.IntegerField()
    stock_critico = models.IntegerField()
    proveedor = models.ForeignKey(proveedor, on_delete=models.PROTECT)
    imagen = models.ImageField(upload_to='productos', null=True)
    oferta = models.BooleanField(default='0', null=False)

    def __str__(self):
        return self.nombre


opciones_consultas = [

    [0, 'Consulta'],
    [1, 'Reclamo'],
    [2, 'Sugerencia'],
    [3, 'Felicitaciones'],
    [4, 'Solicitud de Proveedor']]

class contacto(models.Model):
    nombre = models.CharField(max_length=50)
    correo = models.EmailField()
    tipo_consulta = models.IntegerField(choices=opciones_consultas)
    mensaje = models.TextField()

    def __str__(self):
        return self.nombre



class boleta(models.Model):
    fecha = models.DateField(default=datetime.today)
    producto = models.ForeignKey(producto, on_delete=models.CASCADE)
    canitdad_producto = models.IntegerField()
    total = models.IntegerField()

    def __str__(self):
        return self.id

opciones_estados = [
    [0, 'Pendiente'],
    [1,'Aprobada'],
    [2,'Rechazada'],
]

class ordencompra(models.Model):
    proveedor = models.ForeignKey(proveedor,on_delete=models.CASCADE)
    documento = models.FileField(null=True,blank=True)
    estado = models.BigIntegerField(choices=opciones_estados, null=True, default=0)

    def __str__(self):
        return self.id