from django.shortcuts import render,redirect
from .controllers import pedido_get, productos_get



# Create your views here.
def pedido(request):
    cargo=request.session['cargo']
    if cargo!='Proveedor' and 'Cliente Interno' and 'Cliente Externo':
        return redirect(to="http://127.0.0.1:3000/")
    resp = {
        'pedidos':pedido_get(),
        'producto':productos_get(),
        'cargo':cargo,
    }
    return render(request, 'app/productos.html',resp)