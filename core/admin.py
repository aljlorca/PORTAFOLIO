from django.contrib import admin
from .models import *
from usuario.models import *
# Register your models here.

#
class ProductoAdmin(admin.ModelAdmin):
    list_display = ['nombre','descripcion','precio','vencimiento', 'stock', 'stock_critico']
    list_editable = ['precio']
    search_fields = ['nombre', 'stock']
    list_filter = ['stock','familia']
    list_per_page = 50


class ProveedorAdmin(admin.ModelAdmin):
    list_display = ['rut', 'nombre', 'telefono', 'rubro']



#Muestra tabla en admin para su edición
admin.site.register(familia)
admin.site.register(proveedor, ProveedorAdmin)
admin.site.register(producto, ProductoAdmin)
admin.site.register(contacto)   

