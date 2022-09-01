from django.urls import path
from .views import CargoView

urlpatterns = [
    path('cargo/',CargoView.as_view(),name='cargo_list'),
    path('cargo/<int:id>',CargoView.as_view(),name='cargo_update'),
]