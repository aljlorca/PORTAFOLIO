from django.shortcuts import render 
from .controllers import pedido_get, productos_get


# Create your views here.
def pedido(request):
    
    resp = {
        'pedidos':pedido_get(),
        'producto':productos_get(),
    }
    
    return render(request, 'app/productos.html',resp)