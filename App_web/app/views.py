from pydoc import render_doc
from django.shortcuts import render
from sklearn.utils import resample

# Create your views here.

def home(request):
    return render(request, 'app/home.html')

def productos(request):
    return render(request, 'app/productos.html')

def contacto(request):
    return render(request, 'app/contacto.html')

def login(request):
    return render(request, 'app/login.html')

def transportista(request):
    return render(request, 'app/carrito.html')

def productor(request):
    return render(request, 'app/productores.html')

def cliente_interno(request):
    return render(request, 'app/clienteinterno.html')

def cliente_externo(request):
    return render(request, 'app/clienteexterno.html')

def checkout(request):
    return render(request, 'app/checkout.html')
    