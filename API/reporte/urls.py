from django.urls import path,include
from .views import ReporteViewset,ReporteHistoricoViewset,ReporteView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('reporte',ReporteViewset,ReporteHistoricoViewset)
router.register('reporte_historico',ReporteHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('reporte_old/',ReporteView.as_view(),name='reporte_list'),
    path('reporte_old/<int:id_reporte>',ReporteView.as_view(),name='reporte_update'),
    
]

