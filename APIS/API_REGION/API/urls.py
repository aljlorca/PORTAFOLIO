from django.urls import path,include
from .views import RegionView,RegionViewset,RegionHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('region',RegionViewset,RegionHistoricoViewset)
router.register('region_historico',RegionHistoricoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('region_old/',RegionView.as_view(),name='region_list'),
    path('region_old/<int:id_region>',RegionView.as_view(),name='region_update'),
    
]

