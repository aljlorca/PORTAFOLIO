from django.urls import path,include
from .views import CalidadView,CalidadViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('calidad',CalidadViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('calidad_old/',CalidadView.as_view(),name='calidad_list'),
    path('calidad_old/<int:id_calidad>',CalidadView.as_view(),name='calidad_update'),
]