import os
from random import randrange
from django.shortcuts import render,redirect
from .models import Producto
from .controllers import *
from django.views.decorators.csrf import csrf_exempt
from django.contrib.sessions import *
import datetime
from carro.context_processor import *
from carro import carro
from django.contrib import messages
import time 
# Create your views here.

def home(request):
    data = get_session(request)
    return render(request, 'app/home.html',data)

def contacto(request):
    data = get_session(request)
    return render(request, 'app/contacto.html',data)

def logout(request):
    logout_controller(request)
    carro.Carro.limpiar_carro(request)
    messages.success(request,'Has cerrado session')
    return redirect(to="http://127.0.0.1:3000/")

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
                    return redirect(to="http://127.0.0.1:3000/proveedor/")
                elif respt[1]=='Transportista':
                    return redirect(to="http://127.0.0.1:3000/transportista/")
                elif respt[1]=='Cliente Interno':
                    try:
                        carro.Carro.limpiar_carro(request)
                    except:
                        pass
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
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")

    return render(request, 'app/Cliente_Interno/menu.html',data)

def carrito(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")
    total = request.POST.get('precio_total')
    data['resultado']=get_initTrxTBK(total,str(data['id_user']))
    return render(request, 'app/carro/carrito.html',data)

def cliente_ecomerce(request):
    data = get_session(request)
    if data['cargo']!='Cliente Interno':
        return redirect(to="http://127.0.0.1:3000/")
    data['producto'] = productos_get()
    data['calidad'] = calidad_get()
    return render(request, 'app/Cliente_Interno/listado_productos.html',data)

def detalle_producto(request, id_producto):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

    data['producto']=producto_get_id(id_producto)
    data['calidad'] = calidad_get()
    return render(request, 'app/Cliente_Interno/ver_producto.html', data)

def checkout(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    data['user'] =  usuario_get_id(str(data['id_user']))
    total = request.POST.get('precio_total')
    data['resultado']=get_initTrxTBK(total,str(data['id_user']))
    return render(request, 'app/carro/checkout.html',data)

def detalle_venta(request,id_venta):
    data = get_session(request)
    if data['cargo']!='Cliente Interno':
        return redirect(to="http://127.0.0.1:3000/")
    data['ventas'] = Ventas_get_id(id_venta)
    id_venta=request.session["id_venta"]
    return render(request, 'app/proveedor/Ver_ventas.html', data)

def pedido_cliente_interno(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno' and data['empresa']!='Persona Natural':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")

    try:
        if request.method == 'POST':
            descripcion = request.POST.get('descripcion')
            fecha_sla = request.POST.get('fecha-sla')
            id_usuario = request.session['id_user']
            try: 
                res = pedido_post(descripcion,fecha_sla,id_usuario)
                if res['message'] == 'Success':
                    messages.success(request,"Pedido Creado Correctamente")
                else:
                    data={'error':'no fue posible crear el pedido'}
            except:
                data={'error':'Estamos teniendo problemas en estos momentos'}
    except:
        data={'error':'Error intente nuevamente'}
    
    return render(request, 'app/Cliente_Interno/pedido.html',data)

def listado_ventas_locales(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno' and data['empresa']!='Persona Natural':
            return redirect(to="http://127.0.0.1:3000/")
        
    except:
        return redirect(to="http://127.0.0.1:3000/")

    try:
        data['venta'] = ventas_get()

    except:
        data={'error':'error de conexion'}
    return render(request, 'app/cliente_externo/listado_ventas.html',data)

def ordenes(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    try:
        data['carrito'] = carrito_get_id(str(data['id_user']))

    except:
        pass

    return render(request, 'app/Cliente_Interno/listado_ordenes.html',data)

def venta_resumen(request, id_venta):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Interno':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")

    data['venta']=Ventas_get_id(id_venta)
    data['subasta']=subasta_aceptada(id_venta)
    data['postulacion']=postulacion_aceptada(id_venta)
    postulacion = data['postulacion']
    postulacionjson = postulacion[0]
    data['producto']=producto_get_id(postulacionjson['id_producto'])
    data['calidad']=calidad_get()


    return render(request,'app/cliente_externo/venta_resumen.html',data)
    

###########################
###Cliente Externo Views###
###########################

def cliente_externo(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Externo':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")

    return render(request, 'app/cliente_externo/menu.html',data)

def pedido(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Externo':
            return redirect(to="http://127.0.0.1:3000/")
    except:
        return redirect(to="http://127.0.0.1:3000/")
    try:
        if request.method == 'POST':
            descripcion = request.POST.get('descripcion')
            fecha_sla = request.POST.get('fecha-sla')
            id_usuario = request.session['id_user']
            try: 
                res = pedido_post(descripcion,fecha_sla,id_usuario)
                if res['message'] == 'Success':
                    messages.success(request,"Pedido Creado Correctamente")
                else:
                    data={'error':'no fue posible crear el pedido'}
            except:
                data={'error':'Estamos teniendo problemas en estos momentos'}
    except:
        data={'error':'Error intente nuevamente'}
    return render(request, 'app/cliente_externo/pedido.html',data)

def listado_ventas(request):
    data = get_session(request)
    try:
        if data['cargo']!='Cliente Externo':
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

def proveedor(request):
    data = get_session(request)
    if data['cargo']!='Proveedor':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/proveedor/menu.html',data)


def productores(request):
    data = get_session(request)
    try:
        data['calidad']=calidad_get()
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
                descripcion_producto = request.POST.get('descripcion-producto')
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
                res = crear_producto(id,nombre_producto,cantidad_producto,precio_producto,ruta,id_calidad,saldo_producto,estado_fila,id_usuario,descripcion_producto)
                messages.success(request,"Producto Creado Correctamente")
        return render(request, 'app/proveedor/productores.html',data)
    except:
        data = get_session(request)
        data['error']='Lo sentimos no fue posible registrar el producto, Fallo en la conexion'
        return render(request, 'app/proveedor/productores.html',data)

def postulaciones(request):
    data = get_session(request)
    try:
        if data['cargo']!='Proveedor':
            return redirect(to="http://127.0.0.1:3000/")

    except:
            return redirect(to="http://127.0.0.1:3000/")
    try:
        data['ventas']=ventas_get()
    except:
        data['error']='error de conexion'
    return render(request, 'app/proveedor/Postulaciones.html',data)

def ingreso_postulacion(request,id_venta):
    data = get_session(request)
    try:
        if data['cargo']!='Proveedor':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    data['calidad']=calidad_get()
    data['venta']= Ventas_get_id(id_venta)
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
            descripcion_producto = request.POST.get('descripcion-producto')
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
            crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,ruta,id_calidad,saldo_producto,estado_fila,id_usuario,descripcion_producto)
            time.sleep(0.5)
            Postulacion_controller(descripcion_postulacion,estado_postulacion,id_venta,id_usuario,id_producto)
            messages.success(request,"Postulacion Creada Correctamente")
    return render(request, 'app/proveedor/Ingreso_postulacion.html',data)

#########################
###Transportista Views###
#########################

def transportista(request):
    data = get_session(request)
    try:
        if data['cargo']!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")

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

def detalle_subasta(request,id_venta):
    try:
        data = get_session(request)
        if data['cargo']!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")
        try:
            id_usuario = request.session['id_user']
            carga=request.session['carga'] 
            capacidad_carga = carga['capacidad_carga']
            tamano_carga = carga['tamano_carga']
            refrigeracion_carga = carga['refrigeracion_carga']
            try:
                data['venta']=Ventas_get_id(id_venta)
                data['subasta']=subasta_get_venta(id_venta)
            except:
                data['error']='Tenemos problemas en estos momentos'
        except:
            data['error']='Favor llenar los datos de carga'
            return redirect(to="http://127.0.0.1:3000/carga/")
    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    if request.method == 'POST':
        monto = request.POST.get('monto')
        try: 
            id_subasta=subasta_post(monto,id_venta,id_usuario)
        except:
            data['error']='favor ingrese un monto'
        time.sleep(1)
        try: 
            salida = carga_post(capacidad_carga,tamano_carga,refrigeracion_carga,id_usuario,id_subasta)
            messages.success(request,"Subasta Creada Correctamente")
            url = 'http://127.0.0.1:3000/detalle_subasta/'+str(id_venta)
            return redirect(to=url)
        except: 
            data['error']='error al registrar su carga'
            try:
                subasta_delete(id_subasta)
            except:
                data['error']='favor ingrese un monto'
    return render(request, 'app/transportista/Ingreso_subasta.html',data)

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
        messages.success(request,"Carga Creada Correctamente")
        return redirect(to='http://127.0.0.1:3000/subasta/')
            
    return render(request, 'app/transportista/ingreso_carga.html',data)

def listado_reportes(request):
    data = get_session(request)
    try:
        if data['cargo']!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    id_usuario = request.session['id_user']
    data['reporte']=subasta_venta_usuario(id_usuario)

    return render(request,'app/transportista/reporte_entrega.html',data)


def reporte(request,id_venta):
    data = get_session(request)
    try:
        if data['cargo']!='Transportista':
            return redirect(to="http://127.0.0.1:3000/")

    except:
        return redirect(to="http://127.0.0.1:3000/")
    
    if request.method == 'POST':
        descripcion = request.POST.get('descripcion-reporte')
        entregados = request.POST.get('productos-entregados')
        perdidos = request.POST.get('productos-perdidos')
        restantes = request.POST.get('productos-restantes')
        id_usuario = request.session['id_user']
        reporte_post(descripcion,entregados,perdidos,restantes,id_venta,id_usuario)
        messages.success(request,"Reporte Generado Correctamente")
        return redirect(to="http://127.0.0.1:3000/listado_reportes/")

    return render(request,'app/transportista/reporte.html',data)




#############
### TBK #####
#############

def tbk_respuesta(request):
    data = get_session(request)
    token=request.get_full_path()
    token=token[-64:]
    res=get_statusTBK(token)
    data['response']=res
    try:
        if res['status']=='AUTHORIZED':
            salida = carrito_post(res['amount'],str(data['id_user']))
            diccionario=carro.Carro.listar_carro(request)
            productos = productos_get()
            c = 0
            for a in productos:
                product = productos[c]
                clave = product['id_producto']
                c=c+1
                try:
                    producto_carrito=diccionario[clave] 
                    producto_delete(str(producto_carrito['id_producto'])) 
                except:
                    pass
    except:
        pass
    carro.Carro.limpiar_carro(request)
    return render(request, 'app/tbk/respt.html',data)