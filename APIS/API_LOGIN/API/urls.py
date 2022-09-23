from django.urls import path,include
from .views import ClienteExternoAuthView



urlpatterns = [
    path('cliente_externo_old/',ClienteExternoAuthView.as_view(),name='cliente_externo_update'),
]
