from collections import namedtuple
from django.urls import path
from django.urls.conf import include
from .views import *    
from django.contrib import admin

urlpatterns = [
    #Home
    path('',home, name='home'), 
    #contacto
    path('contacto/', contacto, name="contacto"),
    #producto
    path('agregarproducto/', agregar_producto, name="agregar_producto"),
    path('listarproducto/', listar_productos, name="listar_producto"),
    path('modificarproducto/<id>/', modificar_producto, name="modificar_producto"),
    path('eliminarproducto/<id>/', eliminar_producto, name="eliminar_producto"),
    #registro
    path('register/', register, name="register"),
    #familia
    path('listar_familias/', listar_familias, name='listar_familias' ),
    path('nueva_familia/', nueva_familia, name='nueva_familia'),
    path('modificarfamilia/<id>/', modificar_familia, name="modificar_familia"),
    path('eliminarfamilia/<id>/', eliminar_familia, name="eliminar_familia"),
    #Factura
    path('listar_factura/', listar_factura,name='listar_factura'),
    path('nueva_factura/', nueva_factura, name='nueva_factura'),
    path('modificarfactura/<id>/', modificar_factura,name='modificar_factura'),
    path('eliminarfactura/<id>/',eliminar_factura,name='eliminar_factura'),
    #Boleta
    path('listar_boleta/', listar_boleta,name='listar_boleta'),
    path('nueva_boleta/', nueva_boleta, name='nueva_boleta'),
    path('modificarboleta/<id>/', modificar_boleta,name='modificar_boleta'),
    path('eliminarboleta/<id>/',eliminar_boleta,name='eliminar_boleta'),
    #Proveedor
    path('listar_proveedor/', listar_proveedor, name='listar_proveedor' ),
    path('nuevo_proveedor/', nuevo_proveedor, name='nuevo_proveedor'),
    path('modificarproveedor/<id>/', modificar_proveedor, name="modificar_proveedor"),
    path('eliminarproveedor/<id>/', eliminar_proveedor, name="eliminar_proveedor"),
    #TBK
    path('tbkRes/', statusTrx, name="tbkRes"),
    #Carrito
    path('cart/', cart, name="cart"),
    #usuario
    path('usuario/<id>/', usuario , name='usuario'),
    path('nuevo_usuario/', nuevo_usuario, name='nuevo_usuario'),
    path('listar_usuario/',listar_usuario , name='listar_usuario'),
    path('modificar_usuario/<id>/',modificar_usuario,name='modificar_usuario'),
    path('eliminarusuario/<id>/',eliminar_usuario, name='eliminar_usuario'),
    #Modulos
    path('empleado/',empleado, name='empleado'),
    path('administrador/',administrador, name='administrador'),
    path('proveedor/',provedor, name='provedor'),
    #OrdenCompra
    path('listar_orden/', listar_orden, name='listar_orden' ),
    path('nueva_orden/', nueva_orden, name='nueva_orden'),
    path('modificarorden/<id>/', modificar_orden, name="modificar_orden"),
    path('eliminarorden/<id>/', eliminar_orden, name="eliminar_orden"),
]