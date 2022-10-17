from django.shortcuts import render
import requests

# Create your views here.


def productos(request):
    response = requests.get('http://127.0.0.1:8010/api/producto/')
    
    
    
    return render(request, 'app/productos.html')





