from django.urls import path,include
from .views import ClienteInternoView,ClienteInternoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('cliente_interno',ClienteInternoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('cliente_interno_old/',ClienteInternoView.as_view(),name='cliente_interno_list'),
    path('cliente_interno_old/<str:rut_cliente_interno>',ClienteInternoView.as_view(),name='cliente_interno_update'),
]