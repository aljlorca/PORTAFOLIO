from django.urls import path
from .views import ClienteExternoView

urlpatterns = [
    path('cliente_externo/',ClienteExternoView.as_view(),name='cliente_externo_list'),
    path('cliente_externo/<int:rut_cliente_externo>',ClienteExternoView.as_view(),name='cliente_externo_update'),
]