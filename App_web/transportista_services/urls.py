from django.urls import path
from .views import *

urlpatterns = [
    path('login_T/',get_transportista, name='get_transportista'),
]   