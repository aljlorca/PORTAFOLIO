from django.urls import path
from .views import *

urlpatterns = [
    path('', home , name="home"),
    path('contacto/', contacto, name="contacto"),
    path('login/', login, name="login"),
    path('carrito/', transportista, name="carrito"),
    path("productores/", productores, name="productores"),
    path("cliente_interno/", cliente_interno, name="clienteinterno.html"),
    path("cliente_externo/", cliente_externo, name="clienteexterno.html"),
    path("checkout/", checkout, name="checkout.html"),
    path("postulacion/", postulacion, name="postulacion"),
    path("logout/", logout, name="logout"),
]
