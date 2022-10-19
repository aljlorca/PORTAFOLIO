from django.shortcuts import render,redirect
from .controllers import pedido_get, productos_get
from app.controllers import get_session



# Create your views here.
def pedido(request):
    
    try:
        cargo=request.session['cargo']
        if cargo!='Proveedor' and 'Cliente Interno' and 'Cliente Externo':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        pass

    usuario=request.session['username']
    cargo=request.session['cargo']
    correo=request.session['email']
    empresa=request.session['company']
    id_usuario = request.session['id_user']
    
    data = {
        'pedidos':pedido_get(),
        'producto':productos_get(),
        'cargo':cargo,
        'usuario':usuario,
        'correo':correo,
        'empresa':empresa,
        'id_user':id_usuario
    }

    return render(request, 'app/productos.html',data)