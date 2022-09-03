from django.urls import path,include
from .views import CargoView,CargoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('cargo',CargoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('cargo/<int:id>',CargoView.as_view(),name='cargo_update'),
]