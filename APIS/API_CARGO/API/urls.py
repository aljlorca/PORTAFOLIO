from django.urls import path,include
from .views import CargoView,CargoViewset,CargoHistoricoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('cargo',CargoViewset,CargoHistoricoViewset)
router.register('cargo_historico',CargoHistoricoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('cargo_old/',CargoView.as_view(),name='cargo_list'),
    path('cargo_old/<int:id_cargo>',CargoView.as_view(),name='cargo_update'),
]