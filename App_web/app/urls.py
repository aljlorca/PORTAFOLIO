from unicodedata import name
from django.urls import path
from .views import productos, home, contacto

urlpatterns = [
    path('', home , name="home"),
    path('productos/', productos , name="productos"),
    path('contacto/', contacto, name="contacto"),
]
