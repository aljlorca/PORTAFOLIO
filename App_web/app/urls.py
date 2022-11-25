from django.urls import path,re_path
from .views import *

urlpatterns = [
    path('', home , name="home"),
    path('contacto/', contacto, name="contacto"),
    path('login/', login, name="login"),
    path("logout/", logout, name="logout"),

    #Cliente Interno
    path('detalle_producto/<str:id_producto>/', detalle_producto , name="detalle_producto"),
    path('carrito/', carrito, name="carrito"),
    path("cliente_interno/", cliente_interno, name="cliente_interno"),
    path('mercado/', cliente_ecomerce , name="mercado"),
    path("checkout/", checkout, name="checkout"),
    path("detalle_venta/<str:id_producto>/", detalle_venta, name="detalle_venta"),
    path('pedido_cliente_interno/', pedido_cliente_interno , name="pedido_cliente_interno"),
    path('listado_ventas_locales/',listado_ventas_locales,name='listado_ventas_locales'),
    path('ordenes/',ordenes,name='ordenes'),
    
    #Cliente Externo
    path("cliente_externo/", cliente_externo, name="cliente_externo"),
    path('pedido/', pedido , name="pedido"),
    path("listado_ventas/", listado_ventas, name="listado_ventas"),

    #Proveedor
    path("productores/", productores, name="productores"),
    path("postulaciones/", postulaciones, name="postulaciones"),
    path("ingreso_postulacion/<int:id_venta>", ingreso_postulacion, name="ingreso_postulacion"),
    path("proveedor/", proveedor , name="proveedor"),

    #Transportista
    path("transportista/", transportista, name="transportista"),
    path("subasta/", subasta, name="subasta"),
    path("detalle_subasta/<int:id_venta>", detalle_subasta, name="detalle_subasta"),
    path("carga/", carga, name="carga"),
    path("listado_reportes/",listado_reportes, name="listado_reportes"),
    path("reporte/<str:id_venta>",reporte, name="reporte")

    #tbk
    path('tbk_respuesta/',tbk_respuesta,name='tbk_respuesta')

]
