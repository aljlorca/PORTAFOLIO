from . import views
from django.urls import path
app_name="carro"

urlpatterns = [
    path('agregar/<int:producto_id>/', views.agregar_producto, name="agregar"),
    path('agregar_home/<int:producto_id>/', views.agregar_home, name="agregar_home"),
    path('eliminar/<int:producto_id>/', views.eliminar_producto, name="eliminar"), 
    path('restar/<int:producto_id>/', views.restar_producto, name="restar"), 
    path('limpiar/', views.limpiar_carro, name="limpiar"), 
    path('limpiar_producto/', views.limpiar_carro_producto, name="limpiar_producto"), 
]