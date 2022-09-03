from django.urls import path,include
from .views import AdministradorView,AdministradorViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('administrador',AdministradorViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('administrador/',AdministradorView.as_view(),name='administrador_list'),
    path('administrador/<int:rut_administrador>',AdministradorView.as_view(),name='administrador_update'),
]