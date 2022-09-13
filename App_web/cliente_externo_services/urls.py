from django.urls import path
from .views import *

urlpatterns = [
    path('login_CE/',get_cliente_externo, name='get_cliente_externo'),
]