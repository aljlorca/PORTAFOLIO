from django.urls import path,include
from .views import AdministradorViewset,TransportistaViewset,ClienteExternoViewset,ClienteInternoViewset,ProveedorViewset
from rest_framework import routers


router = routers.DefaultRouter()
router.register('administrador_auth',AdministradorViewset)
router.register('transportista_auth',TransportistaViewset)
router.register('cliente_interno_auth',ClienteInternoViewset)
router.register('cliente_externo_auth',ClienteExternoViewset)
router.register('proveedor_auth',ProveedorViewset)



urlpatterns = [
    path('',include(router.urls)),
]
