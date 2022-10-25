from distutils.log import error
import imp
import os
from random import randrange
from django.shortcuts import render,redirect
from urllib3 import Retry
from .models import Producto
from .controllers import *
from django.views.decorators.csrf import csrf_exempt
from django.contrib.sessions import *
import datetime
from carro.context_processor import *
import carro
# Create your views here.

def home(request):
    data = get_session(request)
    return render(request, 'app/home.html',data)

def contacto(request):
    data = get_session(request)
    return render(request, 'app/contacto.html',data)

def logout(request):
    mensaje = logout_controller(request)
    data = {'message':mensaje}
    return redirect(to="http://127.0.0.1:3000/")

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
                    return redirect(to="http://127.0.0.1:3000/transportista/")
                elif respt[1]=='Cliente Interno':
                    return redirect(to="http://127.0.0.1:3000/cliente_interno/")
                elif respt[1]=='Cliente Externo':
                    return redirect(to="http://127.0.0.1:3000/cliente_externo/")
                elif respt[1]=='Admninistrador':
                    return redirect(to="http://127.0.0.1:3000/logout/")
            if salida['message'] == 'ERROR: usuario No Encontrado':
                data = {"error":'Falló al iniciar sesion Usuario o contraseña incorrectos'}
                return render(request, 'app/login.html',data)
    
    except:
        data = {"error":'error de conexion'}
        return render(request, 'app/login.html',data)
    return render(request, 'app/login.html')

###########################
###Cliente Interno Views###
###########################

def cliente_interno(request):
    data = get_session(request)
    if data['cargo']!='Cliente Interno':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/Cliente_Interno/menu.html',data)

def carrito(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")

    return render(request, 'app/carro/carrito.html',data)

def cliente_ecomerce(request):
    data = get_session(request)
    if data['cargo']!='Cliente Interno':
        return redirect(to="http://127.0.0.1:3000/")
    data['producto'] = productos_get()

    return render(request, 'app/Cliente_Interno/listado_productos.html',data)

def detalle_producto(request, id_producto):
    session = get_session(request)
    try:
        cargo=request.session['cargo']
        if cargo!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    data = {
        'producto':producto_get_id(id_producto),
        'cargo': session['cargo'],
        'usuario': session['usuario'],
        'empresa': session['correo'],
        'id_user': session['id_user'],
        'empresa':session['empresa'],
    }
    return render(request, 'app/Cliente_Interno/ver_producto.html', data)

def checkout(request):
    try:
        cargo=request.session['cargo']
        if cargo!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

    session = get_session(request)
    user =  usuario_get_id(str(session['id_user']))
    data = {
        'user':user,
        'cargo': session['cargo'],
        'usuario': session['usuario'],
        'empresa': session['correo'],
        'empresa':session['empresa'],
        'country':get_pais_id(str(user['id_pais'])),
        'ciudad' :get_ciudad_id(str(user['id_ciudad'])),
        'region' :get_region_id(str(user['id_region'])),
    }    
    return render(request, 'app/carro/checkout.html',data)

def detalle_venta(request,id_venta):
    session = get_session(request)
    if session['cargo']!='Cliente Interno':
        return redirect(to="http://127.0.0.1:3000/")
    data = {
        'ventas':Ventas_get_id(id_venta),
        'cargo': session['cargo'],
        'usuario': session['usuario'],
        'empresa': session['correo'],
        'id_user': session['id_user'],
        'empresa':session['empresa'],
    }
    id_venta=request.session["id_venta"]
    return render(request, 'app/proveedor/Ver_ventas.html', data)

###########################
###Cliente Externo Views###
###########################

def cliente_externo(request):
    try:
        cargo=request.session['cargo']
        if cargo!='Cliente Externo':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    
    session = get_session(request)

    return render(request, 'app/cliente_externo/menu.html',session)

@csrf_exempt
def pedido(request):
    data = get_session(request)

    try:
        cargo=request.session['cargo']
        if cargo!='Cliente Externo':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

    try:
        if request.method == 'POST':
            descripcion = request.POST.get('descripcion')
            fecha_sla = request.POST.get('fecha-sla')
            id_usuario = request.session['id_user']
            data = pedido_post(descripcion,fecha_sla,id_usuario)
    except:
        data={'error':'no fue posible crear el pedido'}
    return render(request, 'app/cliente_externo/pedido.html',data)

def listado_ventas(request):
    data = get_session(request)

    try:
        cargo=request.session['cargo']
        if cargo!='Cliente Externo':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

    try:
        data['venta'] = ventas_get()

    except:
        data={'error':'error de conexion'}
    return render(request, 'app/cliente_externo/listado_ventas.html',data)

#####################
###Proveedor Views###
#####################

@csrf_exempt
def productores(request):
    data = get_session(request)
    try:
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
                saldo_producto = '1'
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
                
                return render(request, 'app/proveedor/productores.html')
        return render(request, 'app/proveedor/productores.html',data)
    except:
        data = get_session(request)
        data['error']='Lo sentimos no fue posible registrar el producto, Fallo en la conexion'
        return render(request, 'app/proveedor/productores.html',data)

def postulaciones(request):
    session = get_session(request)
    try:
        try:
            cargo=request.session['cargo']
            if cargo!='Proveedor':
                return redirect(to="http://127.0.0.1:3000/")

        except:
            return redirect(to="http://127.0.0.1:3000/")
        data = {
            'ventas':ventas_get(),
            'cargo': session['cargo'],
            'usuario': session['usuario'],
            'empresa': session['correo'],
            'id_user': session['id_user'],
            'empresa':session['empresa'],
        }
        return render(request, 'app/proveedor/Postulaciones.html',data)
    except:
        data = get_session(request) 
        data['error'] ='error de conexion'
        return render(request, 'app/proveedor/Postulaciones.html',data)

@csrf_exempt
def ingreso_postulacion(request,id_venta):
    data = get_session(request)
    try:
        cargo=request.session['cargo']
        if cargo!='Proveedor':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    if request.method == 'POST':
            company=request.session['company']
            company=company.replace(' ','_')
            fecha = datetime.datetime.now()
            fecha=fecha.strftime("%d%m%y%H%M%S")
            id_producto  = company+str(randrange(1,10000))+fecha
            descripcion_postulacion = request.POST.get('descripcion-postulacion')
            estado_postulacion = 'licitacion'
            id_usuario = request.session['id_user']
            nombre_producto = request.POST.get('nombre-producto')
            cantidad_producto = request.POST.get('cantidad-producto')
            precio_producto = request.POST.get('precio-producto')
            imagen_producto =  request.FILES['imagen-producto']
            id_calidad = request.POST.get('calidad-producto')
            saldo_producto = '0'
            estado_fila= '1'
            try: 
                producto=Producto.objects.get(id_producto=id_producto,imagen_producto=imagen_producto)
            except Producto.DoesNotExist:
                producto = Producto(id_producto=id_producto,imagen_producto=imagen_producto)
                producto.save()

            buscar = str(producto)
            ruta_proyecto = os.getcwd()+'/media/'
            ruta = ruta_proyecto+buscar
            crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,ruta,id_calidad,saldo_producto,estado_fila,id_usuario)
            Postulacion_controller(descripcion_postulacion,estado_postulacion,id_venta,id_usuario,id_producto)
    return render(request, 'app/proveedor/Ingreso_postulacion.html',data)

#########################
###Transportista Views###
#########################

def transportista(request):
    try:
        cargo=request.session['cargo']
        if cargo!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

    
    data = get_session(request)

    return render(request, 'app/transportista/menu.html',data)

def subasta(request):
    session = get_session(request)
    try:
        try:
            cargo=request.session['cargo']
            if cargo!='Transportista':
                return redirect(to="http://127.0.0.1:3000/")

        except:
            return redirect(to="http://127.0.0.1:3000/")
        data = {
            'ventas':ventas_get(),
            'subasta':subasta_get(),
            'cargo': session['cargo'],
            'usuario': session['usuario'],
            'empresa': session['correo'],
            'id_user': session['id_user'],
            'empresa':session['empresa'],
        }
        return render(request, 'app/transportista/listado_subastas.html',data)
    except:
        data = get_session(request) 
        data['error'] ='error de conexion'
        return render(request, 'app/transportista/listado_subastas.html',data)

@csrf_exempt
def detalle_subasta(request,id_venta):
    try:
        data = get_session(request)
        id_usuario = request.session['id_user']
        carga=request.session['carga'] 
        capacidad_carga = carga['capacidad_carga']
        tamano_carga = carga['tamano_carga']
        refrigeracion_carga = carga['refrigeracion_carga']
    except:
        return redirect(to="http://127.0.0.1:3000/carga/")
    try:
        cargo=request.session['cargo']
        if cargo!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    data['venta']=Ventas_get_id(id_venta)
    data['subasta']=subasta_get()
    try:
        carga=request.session['carga'] 
    except:
        data['error']='Favor llenar los datos de carga'
        return redirect(to="http://127.0.0.1:3000/carga/")

    
    if request.method == 'POST':
        monto = request.POST.get('monto')
        id_subasta=subasta_post(monto,id_venta,id_usuario)
        carga_post(capacidad_carga,tamano_carga,refrigeracion_carga,id_usuario,id_subasta)
    

    return render(request, 'app/transportista/Ingreso_subasta.html',data)

@csrf_exempt
def carga(request):
    data = get_session(request)
    try:
        if data['cargo']!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

    if request.method == 'POST':
        capacidad = request.POST.get('capacidad-carga')
        tamano = request.POST.get('tamano-carga')
        refrigeracion = request.POST.get('refrigeracion-carga')
        data['carga']={'capacidad_carga':capacidad,'tamano_carga':tamano,'refrigeracion_carga':refrigeracion}
        request.session['carga'] = data['carga']
        return redirect(to='http://127.0.0.1:3000/subasta/')
            
    return render(request, 'app/transportista/ingreso_carga.html',data)


def proveedor(request):
    data = get_session(request)
    if data['cargo']!='Proveedor':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/proveedor/menu.html',data)