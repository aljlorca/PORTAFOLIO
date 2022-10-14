from django.urls import path,include
from .views import VentaExternaViewset,VentaExternaHistoricoViewset,VentaExternaView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('venta_externa',VentaExternaViewset,VentaExternaHistoricoViewset)
router.register('venta_externa_historico',VentaExternaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('venta_externa_old/',VentaExternaView.as_view(),name='venta_externa_list'),
    path('venta_externa_old/<int:id_venta_externa>',VentaExternaView.as_view(),name='venta_externa_update'),
    
]