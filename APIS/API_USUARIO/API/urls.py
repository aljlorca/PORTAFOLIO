from django.urls import path,include
from .views import UsuarioViewset,UsuarioHistoricoViewset,UsuarioView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('usuario',UsuarioViewset,UsuarioHistoricoViewset)
router.register('usuario_historico',UsuarioHistoricoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('usuario_old/',UsuarioView.as_view(),name='usuario_list'),
    path('usuario_old/<int:id_usuario>',UsuarioView.as_view(),name='usuario_update'),
    
]



