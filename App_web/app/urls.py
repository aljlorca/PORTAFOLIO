from django.urls import path
from .views import *

urlpatterns = [
    path('', home , name="home"),
    path('contacto/', contacto, name="contacto"),
    path('login/', login, name="login"),
    path("logout/", logout, name="logout"),

    #Cliente Interno
    path('detalle_producto/<str:id_producto>/', detalle_producto , name="detalle_producto"),
    path('carrito/', carrito, name="carrito"),
    path("cliente_interno/", cliente_interno, name="cliente_interno"),
    path('mercado/', cliente_ecomerce , name="mercado"),
    path("checkout/", checkout, name="checkout"),
    path("detalle_venta/<str:id_producto>/", detalle_venta, name="detalle_venta"),

    #Cliente Externo
    path("cliente_externo/", cliente_externo, name="cliente_externo"),
    path('pedido/', pedido , name="pedido"),
    path("listado_ventas/", listado_ventas, name="listado_ventas"),

    #Proveedor
    path("productores/", productores, name="productores"),
    path("ingreso_productos/", ingreso_productos, name="ingreso_productos"),
    path("postulaciones/", postulaciones, name="postulaciones"),
    path("ingreso_postulacion/", ingreso_postulacion, name="ingreso_postulacion"),

    #Transportista
    path("transportista/", transportista, name="transportista"),


]
