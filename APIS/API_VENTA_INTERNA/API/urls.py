from django.urls import path,include
from .views import VentaInternaView,VentaInternaViewset,VentaInternaHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('venta_interna',VentaInternaViewset,VentaInternaHistoricoViewset)
router.register('venta_interna_historico',VentaInternaHistoricoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('venta_interna_old/',VentaInternaView.as_view(),name='venta_interna_list'),
    path('venta_interna_old/<int:id_region>',VentaInternaView.as_view(),name='venta_interna_update'),
    
]
