from symbol import import_as_name
from django.urls import path,include
from .views import UsuarioAuthView,UsuarioHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('usuario',UsuarioHistoricoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('usuario_auth/',UsuarioAuthView.as_view(),name='usuario_auth'),
]
