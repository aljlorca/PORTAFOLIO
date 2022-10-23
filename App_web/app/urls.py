from django.urls import path
from .views import *

urlpatterns = [
    path('', home , name="home"),
    path('contacto/', contacto, name="contacto"),
    path('login/', login, name="login"),
    path('carrito/', carrito, name="carrito"),
    path("productores/", productores, name="productores"),
    path("cliente_interno/", cliente_interno, name="cliente_interno"),
    path('mercado/', cliente_ecomerce , name="mercado"),
    path('detalle_producto/<str:id_producto>/', detalle_producto , name="detalle_producto"),
    path("cliente_externo/", cliente_externo, name="cliente_externo"),
    path("checkout/", checkout, name="checkout"),
    path("ingreso_productos/", ingreso_productos, name="ingreso_productos"),
    path("logout/", logout, name="logout"),
    path('pedido/', pedido , name="pedido"),
    path("postulaciones/", postulaciones, name="postulaciones"),
    path("ingreso_postulacion/", ingreso_postulacion, name="ingreso_postulacion"),
    path("detalle_venta/<str:id_producto>/", detalle_venta, name="detalle_venta"),
    path("listado_ventas/", listado_ventas, name="listado_ventas"),

]
