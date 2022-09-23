from django.urls import path,include
from .views import ContratoView, ContratoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('transportista',ContratoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('contrato_old/',ContratoView.as_view(),name='contrato_list'),
    path('contrato_old/<int:id_Contrato>',ContratoView.as_view(),name='contrato_update'),
]