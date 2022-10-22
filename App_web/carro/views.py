import requests
import carro
from django.shortcuts import render
from .carro import Carro
from app.controllers import producto_get_id
from django.shortcuts import redirect


def eliminar_producto(request, producto_id):
    carro=Carro(request)
    Producto=producto_get_id(producto_id)
    carro.eliminar(Producto=Producto)
    return redirect("http://127.0.0.1:3000/carrito/")

def restar_producto(request, producto_id):
    carro=Carro(request)
    Producto=producto_get_id(producto_id)
    carro.restar_producto(Producto=Producto)
    return redirect("http://127.0.0.1:3000/carrito/")

def limpiar_carro(request):
    carro=Carro(request)
    carro.limpiar_carro()
    return redirect("cart")

def limpiar_carro_producto(request):
    carro=Carro(request)
    carro.limpiar_carro()
    return redirect("http://127.0.0.1:3000/carrito/")

#Los agregados de producto deben tener sus propios views, url's y
#definirlos en "carro" debido a la redireccion que se le debe de dar
def agregar_producto(request, producto_id):
    carro=Carro(request)
    producto = producto_get_id(producto_id)
    carro.agregar(Producto=producto)
    url = 'http://127.0.0.1:3000/detalle_producto/'+str(producto_id)+'/'
    return redirect(url)

def agregar_home(request,producto_id):
    carro=Carro(request)
    producto = producto_get_id(producto_id)
    carro.agregar(Producto=producto)
    return redirect("http://127.0.0.1:3000/mercado/")


