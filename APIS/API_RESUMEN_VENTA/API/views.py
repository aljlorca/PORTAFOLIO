from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import ResumenVenta
from .serializers import ResumenVentaSerializer,ResumenVentaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_resumen_venta(monto_neto_venta,descripcion_resumen,id_venta_externa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('RESUMEN_VENTA_AGREGAR',[monto_neto_venta,descripcion_resumen,id_venta_externa,estado_fila,salida])
    return salida

def modificar_resumen_venta(id_resumen,monto_neto_venta,descripcion_resumen,id_venta_externa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('RESUMEN_VENTA_MODIFICAR',[id_resumen,monto_neto_venta,descripcion_resumen,id_venta_externa,salida])

def eliminar_resumen_venta(id_resumen):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('RESUMEN_VENTA_ELIMINAR',[id_resumen,salida])

def lista_resumen_venta():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('RESUMEN_VENTA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class ResumenVentaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_resumen=0):
        if(id_resumen > 0):
            resumenes=list(ResumenVenta.objects.filter(id_resumen=id_resumen).values())
            if len(resumenes) > 0:
                resumen = resumenes[0]
                datos={'message':"Success","resumen_venta":resumen}
            else:
                datos={'message':"ERROR: reporte No Encontrado"}
            return JsonResponse(datos)
        else:
            resumenes = list(ResumenVenta.objects.values())
            if len(resumenes) > 0:
                datos={'message':"Success","resumen_venta":resumenes}
            else:
                datos={'message':"ERROR: resumenes de venta No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_resumen_venta(monto_neto_venta=jd['monto_neto_venta'],descripcion_resumen=jd['descripcion_resumen'],id_venta_externa=jd['id_venta_externa'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_resumen):
        jd = json.loads(request.body)
        resumenes = list(ResumenVenta.objects.filter(id_resumen=id_resumen).values())
        if len(resumenes) > 0:
            modificar_resumen_venta(id_resumen=jd['id_resumen'],monto_neto_venta=jd['monto_neto_venta'],descripcion_resumen=jd['descripcion_resumen'],id_venta_externa=jd['id_venta_externa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el resumen de venta"}
        return JsonResponse(datos)

    def delete(self, request,id_resumen):
        resumenes = list(ResumenVenta.objects.filter(id_resumen=id_resumen).values())
        jd = json.loads(request.body)
        if len(resumenes) > 0:
            eliminar_resumen_venta(id_resumen=jd['id_resumen'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el resumen de venta"}
        return JsonResponse(datos)

class ResumenVentaViewset(viewsets.ModelViewSet):
    queryset = ResumenVenta.objects.filter(estado_fila='1')
    serializer_class = ResumenVentaSerializer


class ResumenVentaHistoricoViewset(viewsets.ModelViewSet):
    queryset = ResumenVenta.objects.all()
    serializer_class = ResumenVentaHistoricoSerializer