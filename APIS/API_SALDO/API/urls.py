from django.urls import path,include
from .views import SaldoViewset,SaldoHistoricoViewset,SaldoView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('saldo',SaldoViewset,SaldoHistoricoViewset)
router.register('saldo_historico',SaldoHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('saldo_old/',SaldoView.as_view(),name='saldo_list'),
    path('saldo_old/<int:id_saldo>',SaldoView.as_view(),name='saldo_update'),
    
]

