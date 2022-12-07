from django.urls import path,include
from .views import UsuarioAuthView
from rest_framework import routers



urlpatterns = [
    path('usuario_auth/',UsuarioAuthView.as_view(),name='usuario_auth'),
]
