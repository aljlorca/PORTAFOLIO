from django.urls import path,include
from .views import SubastaViewset,SubastaHistoricoViewset,SubastaView,SubastaVentaView,SubastaAceptarView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('subasta',SubastaViewset,SubastaHistoricoViewset)
router.register('subasta_historico',SubastaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('subasta_old/',SubastaView.as_view(),name='subasta_list'),
    path('subasta_old/<int:id_subasta>',SubastaView.as_view(),name='subasta_update'),
    path('subasta_venta/<int:id_venta>',SubastaVentaView.as_view(),name='subasta_venta'),
    path('subasta_aceptar/<str:id_subasta>',SubastaAceptarView.as_view(),name='subasta_aceptar'),
    
]

