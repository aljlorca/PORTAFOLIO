from django.urls import path,include
from .views import PedidoViewset,PedidoHistoricoViewset,PedidoView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('pedido',PedidoViewset,PedidoHistoricoViewset)
router.register('pedido_historico',PedidoHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('pedido_old/',PedidoView.as_view(),name='pedido_list'),
    path('pedido_old/<int:id_pedido>',PedidoView.as_view(),name='pedido_update'),
    
]

