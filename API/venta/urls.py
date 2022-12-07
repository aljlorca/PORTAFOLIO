from django.urls import path,include
from .views import VentaViewset,VentaHistoricoViewset,VentaView,VentaCliente
from rest_framework import routers

router = routers.DefaultRouter()
router.register('venta',VentaViewset,VentaHistoricoViewset)
router.register('venta_historico',VentaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('venta_old/',VentaView.as_view(),name='venta_list'),
    path('venta_old/<int:id_venta>',VentaView.as_view(),name='venta_update'),
    path('venta_cliente/<str:id_venta>',VentaCliente.as_view(),name='venta_cliente'),

]