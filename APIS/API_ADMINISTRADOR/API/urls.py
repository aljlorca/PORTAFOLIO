from django.urls import path
from .views import AdministradorView

urlpatterns = [
    path('administrador/',AdministradorView.as_view(),name='administrador_list'),
    path('administrador/<int:rut_administrador>',AdministradorView.as_view(),name='administrador_update'),
]