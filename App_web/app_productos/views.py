from django.shortcuts import render 
from .controllers import pedido_get


# Create your views here.


def productos(request):
    
    resp = {"pedidos":pedido_get()}
    return render(request, 'app/productos.html',resp)




