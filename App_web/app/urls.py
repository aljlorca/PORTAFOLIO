from unicodedata import name
from django.urls import path
from .views import productos, home, contacto, login, transportista, productor, cliente_interno, cliente_externo, checkout

urlpatterns = [
    path('', home , name="home"),
    path('productos/', productos , name="productos"),
    path('contacto/', contacto, name="contacto"),
    path('login/', login, name="login"),
    path('carrito/', transportista, name="carrito"),
    path("productores/", productor, name="productor"),
    path("cliente_interno/", cliente_interno, name="clienteinterno.html"),
    path("cliente_externo/", cliente_externo, name="clienteexterno.html"),
    path("checkout/", checkout, name="checkout.html")
]
