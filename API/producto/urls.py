from django.urls import path,include
from .views import ProductoView, ProductoViewset,ProductoHistoricoViewset,ProductoVentaView,ProductoBest
from rest_framework import routers

router = routers.DefaultRouter()
router.register('producto',ProductoViewset,ProductoHistoricoViewset)
router.register('producto_historico',ProductoHistoricoViewset)

urlpatterns = [
    path('',include(router.urls)),
    path('producto_old/',ProductoView.as_view(),name='producto_list'),
    path('producto_old/<str:id_producto>',ProductoView.as_view(),name='producto_update'),
    path('producto_venta/<str:id_venta>',ProductoVentaView.as_view(),name='producto_venta'),
    path('producto_best/<str:id_venta>',ProductoBest.as_view(),name='producto_best'),
]