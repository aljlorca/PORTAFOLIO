from django.urls import path
from .views import *

urlpatterns = [
    path('login_P/',get_proveedor, name='get_proveedor'),
]   