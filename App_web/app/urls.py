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
    path('detalle_producto/<id_producto>/', detalle_producto , name="detalle_producto"),
    path("cliente_externo/", cliente_externo, name="clienteexterno.html"),
    path("checkout/", checkout, name="checkout.html"),
    path("ingreso_productos/", ingreso_productos, name="ingreso_productos"),
    path("logout/", logout, name="logout"),
    path('pedido/', pedido , name="pedido"),
    path("postulaciones/", postulaciones, name="postulaciones"),


]
