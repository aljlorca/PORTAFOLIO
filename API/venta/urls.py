from django.urls import path,include
from .views import VentaViewset,VentaHistoricoViewset,VentaView,VentaClienteAceptar,VentaClienteRechazar,VentaReporte
from rest_framework import routers

router = routers.DefaultRouter()
router.register('venta',VentaViewset,VentaHistoricoViewset)
router.register('venta_historico',VentaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('venta_old/',VentaView.as_view(),name='venta_list'),
    path('venta_old/<int:id_venta>',VentaView.as_view(),name='venta_update'),
    path('venta_cliente_aceptar/<str:id_venta>',VentaClienteAceptar.as_view(),name='venta_cliente_aceptar'),
    path('venta_cliente_rechazar/<str:id_venta>',VentaClienteRechazar.as_view(),name='venta_cliente_rechazar'),
    path('venta_reporte/<str:id_venta>',VentaReporte.as_view(),name='venta_reporte'),


    
]