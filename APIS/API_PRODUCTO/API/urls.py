from django.urls import path,include
from .views import ProductoView, ProductoViewset
from rest_framework import routers

router = routers.DefaultRouter()
router.register('producto',ProductoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('producto_old/',ProductoView.as_view(),name='producto_list'),
    path('producto_old/<int:id_producto>',ProductoView.as_view(),name='producto_update'),
]