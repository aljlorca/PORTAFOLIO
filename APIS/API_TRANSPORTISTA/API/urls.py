from django.urls import path
from .views import TransportistaView

urlpatterns = [
    path('transportista/',TransportistaView.as_view(),name='transportista_list'),
    path('transportista/<int:rut_transportista>',TransportistaView.as_view(),name='transportista_update'),
]