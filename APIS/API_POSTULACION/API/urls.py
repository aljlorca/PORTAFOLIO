from django.urls import path,include
from .views import PostulacionViewset,PostulacionHistoricoViewset,PostulacionView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('postulacion',PostulacionViewset,PostulacionHistoricoViewset)
router.register('postulacion_historico',PostulacionHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('postulacion_old/',PostulacionView.as_view(),name='postulacion_list'),
    path('postulacion_old/<int:id_postulacion>',PostulacionView.as_view(),name='postulacion_update'),
    
]

