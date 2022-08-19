from factura.models import factura
from usuario.models import Usuario
from django.forms.forms import Form
import carro
from django.contrib.messages.api import success
from django.core import paginator
from django.http import request
from django.http.response import Http404
from django.shortcuts import render, redirect, get_object_or_404
from .models import  *
from .forms import *
from django.contrib import messages
from django.core.paginator import Paginator
from django.contrib.auth import authenticate,login
from django.db import connection
import cx_Oracle
from django.views.decorators.csrf import csrf_exempt
from .services import *
from carro.context_processor import *
import json
from usuario.forms import FormularioUsuario, FormularioUsuarioCompleto,AgregadoAdminForms
from factura.forms import FacturaForm
from boleta.forms import BoletaForm
from boleta.models import boleta
from proveedor.models import proveedor
from proveedor.forms import AgregarProveedorForms

# Create your views here.
#Home de la pagina
def home(request):
    productos = producto.objects.all() 
    data = {
        'producto': productos,
    }
    return render(request, 'core/home.html', data)
#formulario de contacto
def contacto(request):
    data = {
        'form': ContactoForms()
    }
    if request.method == 'POST':
        formulario = ContactoForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            data["mensaje"] = "contacto guardado"
        else:
            data["form"] = formulario
    return render(request, 'core/Contacto.html',data)
#Productos
#Procedimiento para agregar producto
def agregar_producto(request):

    data = {
        'form': AgregarProductoForms()  
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, "Producto registrado correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: El producto no fue registrado")

    return render(request, 'core/producto/agregar.html', data)
#Funcion listar prodcutos
def listar_productos(request):
    data = {
        'familias':familia.objects.all(),
        'producto':producto.objects.all(),
    }
    return render(request, 'core/producto/listar.html',data)
#Procedimiento listar productos''''
'''def lista_prodcuto():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('core_productos_listar', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista'''
#Procedimiento para modificar producto
def modificar_producto(request, id):
    product = get_object_or_404(producto, id=id)
    data = {
        'form': AgregarProductoForms(instance=product)
    }
    if request.method == 'POST':
        formulario = AgregarProductoForms(data=request.POST,instance=product, files=request.FILES)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Producto modificado correctamente ")
            return redirect(to="listar_producto")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: No se pudo modificar el producto")
    return render(request, 'core/producto/modificar.html', data)
#Procedimiento para eliminar producto
def eliminar_producto(request, id ):
    prod = get_object_or_404(producto, id=id)
    prod.delete()
    messages,success(request, "Producto eliminado correctamente")
    return redirect(to="listar_producto")
#Registro de clientes
def register(request):
    data = {
        'form':FormularioUsuario()
    }
    if request.method == 'POST':
        formulario = FormularioUsuario(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            user = authenticate(username=formulario.cleaned_data["username"],password=formulario.cleaned_data["password1"])
            login(request, user)
            messages.success(request, "Registro exitoso")
            return redirect(to="home")
        data['from'] = formulario
    return render(request, 'registration/register.html', data)

#Familias
#Funcion listar familias
def listar_familias(request):
    data = {
        'familia':listar_familia()
    }
    return render(request, 'core/familia/listar.html', data)
#funcion de almacenado de familias
def nueva_familia(request):
    data = {
        'form': AgregarFamiliaForms()  
    }
    if request.method == 'POST':
        formulario = AgregarFamiliaForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Familia registrada correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: La Familia no fue registrada")

    return render(request, 'core/familia/agregar.html', data)
#Procedimiento para llamar a las familias
def listar_familia():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('core_familia_listar', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
#Procedimiento para guardar familias
def agregar_familia(nombre):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('core_familia_agregar',[nombre,salida])
    return salida.getvalue()
#Procedimiento para eliminar familia    
def eliminar_familia(request, id ):
    fam = get_object_or_404(familia, id=id)
    fam.delete()
    messages,success(request, "Familia eliminada correctamente")
    return redirect(to="listar_familias")
#Procedimiento para modificar familia
def modificar_familia(request, id):
    famil = get_object_or_404(familia, id=id)
    data = {
        'form': AgregarFamiliaForms(instance=famil)
    }
    if request.method == 'POST':
        formulario = AgregarFamiliaForms(data=request.POST,instance=famil)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Familia modificada correctamente ")
            return redirect(to="listar_familias")
        else:
            data["form"] = formulario
            
    return render(request, 'core/familia/modificar.html', data)


#Proveedores 
#Funcion de listado de proveedores
def listar_proveedor (request):
    prov = proveedor.objects.all()
    data = {
        'proveedor':prov
    }
    return render(request,'core/proveedor/listar.html',data)
#Funcion de almacenado de proveedor
def nuevo_proveedor(request):
    data = {
        'form': AgregarProveedorForms()  
    }
    if request.method == 'POST':
        formulario = AgregarProveedorForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Proveedor registrado correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: El proveedor no fue registrado")

    return render(request, 'core/proveedor/agregar.html', data)
#Procedimiento para eliminar proveedor
def eliminar_proveedor(request, id ):
    prov = get_object_or_404(proveedor, id=id)
    prov.delete()
    messages,success(request, "Proveedor eliminado correctamente")
    return redirect(to="listar_proveedor")
#Modificar Proveedor 
def modificar_proveedor(request, id):
    prov = get_object_or_404(proveedor, id=id)
    data = {
        'form': AgregarProveedorForms(instance=prov)
    }
    if request.method == 'POST':
        formulario = AgregarProveedorForms(data=request.POST,instance=prov)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Proveedor modificado correctamente ")
            return redirect(to="listar_proveedor")
        else:
            data["form"] = formulario
            
    return render(request, 'core/proveedor/modificar.html', data)

#TBK

@csrf_exempt
def statusTrx(request):
    data = {
        'resultado': get_statusTBK(request),
    }
    return render(request, 'core/tbk/statusTbk.html',data)

#Carrito

@csrf_exempt
def cart(request):
    product = producto.objects.all()
    monto = request.POST.get('precio_total')
    data = {
        'producto': product,
        'resultado': get_initTrxTBK(monto),
    }
    return render(request, 'core/carro/cart.html', data)    

#Factura
def nueva_factura(request):
    data = {
        'form':FacturaForm(),
    }
    if request.method == 'POST':
        formulario = FacturaForm(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Factura Registrada correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: la factura no fue registrada")
    return render(request, 'core/factura/agregar.html',data)

def listar_factura(request):
    factur = factura.objects.all()
    data = {
        'factura':factur
    }
    return render(request, 'core/factura/listar.html',data)

def modificar_factura(request,id):
    fact = get_object_or_404(factura, id=id)
    data = {
        'form': FacturaForm(instance=fact)
    }
    if request.method == 'POST':
        formulario = FacturaForm(data=request.POST,instance=fact)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Factura modificada correctamente ")
            return redirect(to="listar_factura")
        else:
            data["form"] = formulario
            
    return render(request, 'core/factura/modificar.html', data)

def eliminar_factura(request,id):
    fact = get_object_or_404(factura, id=id)
    fact.delete()
    messages,success(request, "Factura eliminada correctamente")
    return redirect(to="listar_factura")

#Usuario

def usuario(request,id):
    persona = get_object_or_404(Usuario, id=id)
    data = {
        'form':FormularioUsuario(instance=persona),
    }
    if request.method == 'POST':
        formulario = FormularioUsuario(data=request.POST, instance=persona)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Datos modificados correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: Los datos no fueron actualizados")

    return render(request,'core/persona/modificar.html',data)

def nuevo_usuario(request):
    data = {
        'form':AgregadoAdminForms(),
    }
    if request.method == 'POST':
        formulario = AgregadoAdminForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Usuario Registrado correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: el usuario no fue registrado")
    return render(request, 'core/persona/agregar.html',data)
    
def modificar_usuario(request,id):
    persona = get_object_or_404(Usuario, id=id)
    data = {
        'form':FormularioUsuarioCompleto(instance=persona),
    }
    if request.method == 'POST':
        formulario = FormularioUsuarioCompleto(data=request.POST, instance=persona)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Datos modificados correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: Los datos no fueron actualizados")
    return render(request, 'core/persona/modificar.html',data)

def listar_usuario(request):
    persona = Usuario.objects.all()
    data = {
        'usuario':persona,
    }
    return render(request, 'core/persona/listar.html',data)

def eliminar_usuario(request,id):
    usuari = get_object_or_404(Usuario, id=id)
    usuari.delete()
    messages,success(request, "Usuario eliminadao correctamente")
    return redirect(to="listar_usuario")

#Boleta

def nueva_boleta(request):
    data = {
        'form':BoletaForm(),
    }
    if request.method == 'POST':
        formulario = BoletaForm(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Boleta Registrada correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: la boleta no fue registrada")
    return render(request, 'core/boleta/agregar.html',data)

def listar_boleta(request):
    bolet = boleta.objects.all()
    data = {
        'boleta':bolet
    }
    return render(request, 'core/boleta/listar.html',data)

def modificar_boleta(request,id):
    fact = get_object_or_404(boleta, id=id)
    data = {
        'form': BoletaForm(instance=fact)
    }
    if request.method == 'POST':
        formulario = BoletaForm(data=request.POST,instance=fact)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Boleta modificada correctamente ")
            return redirect(to="listar_boleta")
        else:
            data["form"] = formulario
            
    return render(request, 'core/boleta/modificar.html', data)

def eliminar_boleta(request,id):
    fact = get_object_or_404(boleta, id=id)
    fact.delete()
    messages,success(request, "Boleta eliminada correctamente")
    return redirect(to="listar_boleta")

#Orden Compra
def nueva_orden(request):
    data = {
        'form':AgregarOrdenForms(),
    }
    if request.method == 'POST':
        formulario = AgregarOrdenForms(data=request.POST)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Orden Registrada correctamente ")
        else:
            data["form"] = formulario
            messages.warning(request, "ERROR: la Orden no fue registrada")
    return render(request, 'core/ordencompra/agregar.html',data)

def listar_orden(request):
    orden = ordencompra.objects.all()
    data = {
        'orden':orden
    }
    return render(request,'core/ordencompra/listar.html',data)

def modificar_orden(request,id):
    orden = get_object_or_404(ordencompra, id=id)
    data = {
        'form': ModificarOrdenForms(instance=orden)
    }
    if request.method == 'POST':
        formulario = ModificarOrdenForms(data=request.POST,instance=orden)
        if formulario.is_valid():
            formulario.save()
            messages.success(request, " Orden modificada correctamente ")
            return redirect(to="listar_orden")
        else:
            data["form"] = formulario
            
    return render(request, 'core/ordencompra/modificar.html', data)

def eliminar_orden(request,id):
    orden = get_object_or_404(ordencompra,id=id)
    orden.delete()
    return redirect(to='listar_orden')

#Modulos 
#Modulo proveedor
def provedor(request):

    return render(request, 'core/Modulos/proveedor.html')
#Modulo Administrador
def administrador(request):

    return render(request,'core/Modulos/administrador.html')
#Modulo Empleado
def empleado(request):

    return render(request,'core/Modulos/empleado.html')