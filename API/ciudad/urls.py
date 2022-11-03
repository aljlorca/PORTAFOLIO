from django.urls import path,include
from .views import CiudadView,CiudadViewset,CiudadHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('ciudad',CiudadViewset,CiudadHistoricoViewset)
router.register('ciudad_historico',CiudadHistoricoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('ciudad_old/',CiudadView.as_view(),name='ciudad_list'),
    path('ciudad_old/<int:id_ciudad>',CiudadView.as_view(),name='ciudad_update'),
    
]



