from django.urls import path,include
from .views import ResumenVentaViewset,ResumenVentaHistoricoViewset,ResumenVentaView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('resumen_venta',ResumenVentaViewset,ResumenVentaHistoricoViewset)
router.register('resumen_venta_historico',ResumenVentaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('resumen_venta_old/',ResumenVentaView.as_view(),name='resumen_venta_list'),
    path('resumen_venta_old/<int:id_resumen>',ResumenVentaView.as_view(),name='resumen_venta_update'),
    
]

