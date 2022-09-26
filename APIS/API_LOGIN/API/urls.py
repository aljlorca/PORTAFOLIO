from django.urls import path,include
from .views import ClienteExternoAuthView,ClienteInternoAuthView,ProveedorAuthView,TransportistaAuthView



urlpatterns = [
    path('cliente_externo_auth/',ClienteExternoAuthView.as_view(),name='cliente_externo_update'),
    path('cliente_interno_auth/',ClienteInternoAuthView.as_view(),name='cliente_interno_update'),
    path('cliente_proveedor_auth/',ProveedorAuthView.as_view(),name='cliente_proveedor_update'),
    path('cliente_transportista_auth/',TransportistaAuthView.as_view(),name='cliente_transportista_update'),
]
