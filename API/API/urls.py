"""API URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/4.1/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.urls import path,include
from django.conf import settings
from django.conf.urls.static import static

urlpatterns = [
    path('api_calidad/', include('calidad.urls')),
    path('api_carga/', include('carga.urls')),
    path('api_cargo/', include('cargo.urls')),
    path('api_carrito/', include('carrito.urls')),
    path('api_contrato/', include('contrato.urls')),
    path('api_empresa/', include('empresa.urls')),
    path('api_login/', include('login.urls')),
    path('api_pedido/', include('pedido.urls')),
    path('api_postulacion/', include('postulacion.urls')),
    path('api_producto/', include('producto.urls')),
    path('api_reporte/', include('reporte.urls')),
    path('api_resumen_venta/', include('resumen_venta.urls')),
    path('api_subasta/', include('subasta.urls')),
    path('api_tipo_empresa/', include('tipo_empresa.urls')),
    path('api_usuario/', include('usuario.urls')),
    path('api_venta/', include('venta.urls')),

]

urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)

