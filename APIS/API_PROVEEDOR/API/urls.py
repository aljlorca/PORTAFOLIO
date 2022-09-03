from django.urls import path,include
from .views import ProveedorView,ProveedorViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('Proveedor',ProveedorViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('proveedor/',ProveedorView.as_view(),name='proveedor_list'),
    path('proveedor/<int:rut_proveedor>',ProveedorView.as_view(),name='proveedor_update'),
]