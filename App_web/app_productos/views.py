from django.shortcuts import render
import requests

# Create your views here.


def productos(request):
    response = requests.get('z')
    
    return render(request, 'app/productos.html')



