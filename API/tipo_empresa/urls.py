from django.urls import path,include
from .views import TipoEmpresaViewset,TipoEmpresaHistoricoViewset,TipoEmpresaView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('tipo_empresa',TipoEmpresaViewset,TipoEmpresaHistoricoViewset)
router.register('tipo_empresa_historico',TipoEmpresaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('tipo_empresa_old/',TipoEmpresaView.as_view(),name='tipo_empresa_list'),
    path('tipo_empresa_old/<int:id_tipo_empresa>',TipoEmpresaView.as_view(),name='tipo_empresa_update'),
    
]
