from django.urls import path,include
from .views import TransportistaView, TransportistaViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('transportista',TransportistaViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('transportista_old/',TransportistaView.as_view(),name='transportista_list'),
    path('transportista_old/<int:rut_transportista>',TransportistaView.as_view(),name='transportista_update'),
]