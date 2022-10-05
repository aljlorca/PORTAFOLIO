from django.urls import path,include
from .views import PaisView,PaisViewset,PaisHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('pais',PaisViewset,PaisHistoricoViewset)
router.register('pais_historico',PaisHistoricoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('pais_old/',PaisView.as_view(),name='pais_list'),
    path('pais_old/<int:id_pais>',PaisView.as_view(),name='pais_update'),
    
]



