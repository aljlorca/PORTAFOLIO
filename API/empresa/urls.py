from django.urls import path,include
from .views import EmpresaViewset,EmpresaHistoricoViewset,EmpresaView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('empresa',EmpresaViewset,EmpresaHistoricoViewset)
router.register('empresa_historico',EmpresaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('empresa_old/',EmpresaView.as_view(),name='empresa_list'),
    path('empresa_old/<int:id_empresa>',EmpresaView.as_view(),name='empresa_update'),
    
]

