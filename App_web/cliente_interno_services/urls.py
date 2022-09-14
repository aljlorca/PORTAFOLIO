from django.urls import path
from .views import *

urlpatterns = [
    path('login_CI/',get_cliente_interno, name='get_cliente_interno'),
]   