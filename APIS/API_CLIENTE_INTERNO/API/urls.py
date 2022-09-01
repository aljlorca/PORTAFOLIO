from django.urls import path
from .views import ClienteInternoView

urlpatterns = [
    path('cliente_interno/',ClienteInternoView.as_view(),name='cliente_interno_list'),
    path('cliente_interno/<int:rut_cliente_interno',ClienteInternoView.as_view(),name='cliente_interno_update'),
]