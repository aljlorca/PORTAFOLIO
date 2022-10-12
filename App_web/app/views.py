from django.shortcuts import render
from .controllers import login_controller
from django.views.decorators.csrf import csrf_exempt
# Create your views here.



def home(request):
    return render(request, 'app/home.html')

def productos(request):
    return render(request, 'app/productos.html')

def contacto(request):
    return render(request, 'app/contacto.html')


def login(request):

    data = {
    }
    if request.method == 'POST':
        correo = request.POST('email')
        contrasena = request.POST('password')
        salida = login_controller(correo,contrasena)
        print(salida,correo,contrasena)

    return render(request, 'app/login.html',data,salida)

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
    