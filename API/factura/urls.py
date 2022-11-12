from django.urls import path,include
from .views import FacturaViewset,FacturaHistoricoViewset,FacturaView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('factura',FacturaViewset,FacturaHistoricoViewset)
router.register('factura_historico',FacturaHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('factura_old/',FacturaView.as_view(),name='factura_list'),
    path('factura_old/<int:id_factura>',FacturaView.as_view(),name='factura_update'),
    
]
