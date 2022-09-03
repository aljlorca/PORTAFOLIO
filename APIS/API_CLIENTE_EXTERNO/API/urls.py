from django.urls import path,include
from .views import ClienteExternoView,ClienteExternoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('Cliente_Externo',ClienteExternoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('cliente_externo/',ClienteExternoView.as_view(),name='cliente_externo_list'),
    path('cliente_externo/<int:rut_cliente_externo>',ClienteExternoView.as_view(),name='cliente_externo_update'),
]