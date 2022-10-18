from django.urls import path
from .views import pedido

urlpatterns = [
    path('', pedido , name="pedido"),
    
]