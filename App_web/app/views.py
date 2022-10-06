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