from django.shortcuts import render,redirect
from .controllers import *
from django.views.decorators.csrf import csrf_exempt
# Create your views here.



def home(request):
    return render(request, 'app/home.html')

def productos(request):
    return render(request, 'app/productos.html')

def contacto(request):
    return render(request, 'app/contacto.html')

@csrf_exempt
def login(request):
    try:
        if request.method == 'POST':
            correo = request.POST.get('correo')
            contrasena = request.POST.get('password')
            salida = login_controller(correo,contrasena)    
            if salida['message'] == 'Success':
                respt = salida['usuario']
                if respt[1]=='Proveedor':
                    return redirect(to="http://127.0.0.1:3000/productores/")
                elif respt[1]=='Transportista':
                    return redirect(to="http://127.0.0.1:3000/")
                elif respt[1]=='Cliente Interno':
                    return redirect(to="http://127.0.0.1:3000/cliente_interno/")
                elif respt[1]=='Cliente Externo':
                    return redirect(to="http://127.0.0.1:3000/cliente_externo/")
                elif respt[1]=='Administrador':
                    return redirect(to="http://127.0.0.1:3000/Administrador/")
        else:
            return render(request, 'app/login.html')
                                        
    except:
        return render(request, 'app/login.html',{
                "error":'Falló al iniciar sesion Usuario o contraseña incorrectos, o Ingrese algun dato valido'})
                    
    

def transportista(request):
    return render(request, 'app/carrito.html')

@csrf_exempt
def productores(request):
    try:
        if request.method == 'POST':
            id_producto = request.POST.get('1')
            nombre_producto = request.POST.get('nombre-producto')
            cantidad_producto = request.POST.get('cantidad-producto')
            precio_producto = request.POST.get('precio-producto')
            imagen_producto = request.POST.get('imagen-producto')
            id_calidad = request.POST.get('calidad-producto')
            saldo_producto = request.POST.get('saldo-producto')
            estado_fila= request.POST.get('1')
            id_usuario = request.POST.get('1')
            salida = crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,estado_fila,id_usuario)
            if salida['message'] =='Success':
                return redirect(to="http://127.0.0.1:3000/")
            else:
                return render(request, 'app/productores.html')
    except:
        return render(request, 'app/productores.html')

def cliente_interno(request):
    return render(request, 'app/clienteinterno.html')

def cliente_externo(request):
    return render(request, 'app/clienteexterno.html')

def checkout(request):
    return render(request, 'app/checkout.html')


    
