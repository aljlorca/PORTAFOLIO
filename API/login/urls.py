from django.urls import path,include
from .views import UsuarioAuthView,UsuarioHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('usuario_desktop',UsuarioHistoricoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('usuario_auth/',UsuarioAuthView.as_view(),name='usuario_auth'),
]