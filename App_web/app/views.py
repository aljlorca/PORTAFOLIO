import os
from random import randrange
from django.shortcuts import render,redirect
from .models import Producto
from .controllers import *
from django.views.decorators.csrf import csrf_exempt
from django.contrib.sessions import *
import datetime
# Create your views here.



def home(request):
    data = get_session(request)
    return render(request, 'app/home.html',data)

def contacto(request):
    return render(request, 'app/contacto.html')

def transportista(request):
    data = get_session(request)
    if data['cargo']!='Transportista':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/carrito.html')

@csrf_exempt
def login(request):
    try:
        if request.method == 'POST':
            correo = request.POST.get('correo')
            contrasena = request.POST.get('password')
            salida = login_controller(correo,contrasena)
            if salida['message'] == 'Success':
                respt = salida['usuario']
                request.session['username'] = respt[0]
                request.session['cargo'] = respt[1]
                request.session['email'] = respt[2]
                request.session['company'] = respt[4]
                request.session['id_user'] = respt[5]
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

@csrf_exempt

def productores(request):
    data = get_session(request)
    if data['cargo']!='Proveedor':
        return redirect(to="http://127.0.0.1:3000/")
    if request.method == 'POST':
            company=request.session['company']
            company=company.replace(' ','_')
            fecha = datetime.datetime.now()
            fecha=fecha.strftime("%d%m%y%H%M%S")
            id = company+str(randrange(1,10000))+fecha
            nombre_producto = request.POST.get('nombre-producto')
            cantidad_producto = request.POST.get('cantidad-producto')
            precio_producto = request.POST.get('precio-producto')
            imagen_producto =  request.FILES['imagen-producto']
            id_calidad = request.POST.get('calidad-producto')
            saldo_producto = request.POST.get('saldo-producto')
            estado_fila= '1'
            id_usuario = request.session['id_user']
            try: 
                producto=Producto.objects.get(id_producto=id,imagen_producto=imagen_producto)
            except Producto.DoesNotExist:
                producto = Producto(id_producto=id,imagen_producto=imagen_producto)
                producto.save()

            buscar = str(producto)
            ruta_proyecto = os.getcwd()+'/media/'
            ruta = ruta_proyecto+buscar
            crear_producto(id,nombre_producto,cantidad_producto,precio_producto,ruta,id_calidad,saldo_producto,estado_fila,id_usuario)
            
            return render(request, 'app/productores.html')
    return render(request, 'app/productores.html',data)

def cliente_interno(request):
    data = get_session(request)
    if data['cargo']!='Cliente Interno':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/clienteinterno.html')

def cliente_externo(request):
    data = get_session(request)
    if data['cargo']!='Cliente Externo':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/clienteexterno.html')

def checkout(request):
    return render(request, 'app/checkout.html')

@csrf_exempt
def postulacion(request):
    data = get_session(request)
    try:
        if data['cargo']!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        pass

    if request.method == 'POST':
            monto = request.POST.get('monto')
            id_venta = ''
            id_usuario = '1'
            subasta_controller(monto,id_venta,id_usuario)
            return render(request, 'app/postulacion.html')

    return render(request, 'app/postulacion.html',data)

def logout(request):
    mensaje = logout_controller(request)
    data = {'message':mensaje}
    return redirect(to="http://127.0.0.1:3000/")


