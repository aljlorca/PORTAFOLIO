from django.urls import path,include
from .views import PostulacionesViewset,PostulacionesHistoricoViewset,PostulacionView
from rest_framework import routers

router = routers.DefaultRouter()
router.register('postulacion',PostulacionesViewset,PostulacionesHistoricoViewset)
router.register('postulacion_historico',PostulacionesHistoricoViewset)


urlpatterns = [

    path('',include(router.urls)),
    path('postulacion_old/',PostulacionView.as_view(),name='postulacion_list'),
    path('postulacion_old/<int:id_postulacion>',PostulacionView.as_view(),name='postulacion_update'),
    
]

