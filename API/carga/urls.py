from django.urls import path,include
from .views import CargaView,CargaViewset,CargaSubastaView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('carga',CargaViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('carga_old/',CargaView.as_view(),name='carga_list'),
    path('carga_old/<int:id_carga>',CargaView.as_view(),name='carga_update'),
    path('carga_subasta/<int:id_subasta>',CargaSubastaView.as_view(),name='carga_subasta'),
]