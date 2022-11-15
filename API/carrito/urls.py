from django.urls import path,include
from .views import CarritoView,CarritoViewset,CarritoHistoricoViewset,CarritoUserView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('carrito',CarritoViewset,CarritoHistoricoViewset)
router.register('carrito_historico',CarritoHistoricoViewset)


urlpatterns = [
    path('',include(router.urls)),
    path('carrito_old/',CarritoView.as_view(),name='carrito_list'),
    path('carrito_old/<int:id_carrito>',CarritoView.as_view(),name='carrito_update'),
    path('carrito_user/<int:id_usuario>',CarritoUserView.as_view(),name='carrito_user'),
    
]

