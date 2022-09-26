from django.urls import path,include
from .views import AdministradorAuthViewset, AdministradorView,AdministradorViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('administrador',AdministradorViewset)
router.register('administrador_auth',AdministradorAuthViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('administrador_old/',AdministradorView.as_view(),name='administrador_list'),
    path('administrador_old/<str:rut_administrador>',AdministradorView.as_view(),name='administrador_update'),
]