from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Reporte
from .serializers import ReporteSerializer,ReporteHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_reporte(descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,id_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('REPORTE_AGREGAR',[descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,estado_fila,id_venta,id_usuario,salida])
    return salida

def modificar_reporte(id_reporte,descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,id_venta,id_usuario):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('REPORTE_MODIFICAR',[id_reporte,descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,id_venta,id_usuario,salida])

def eliminar_reporte(id_reporte):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('REPORTE_ELIMINAR',[id_reporte,salida])

def lista_reporte():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('REPORTE_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class ReporteView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_reporte=0):
        if(id_reporte > 0):
            reportes=list(Reporte.objects.filter(id_reporte=id_reporte).values())
            if len(reportes) > 0:
                reporte = reportes[0]
                datos={'message':"Success","reporte":reporte}
            else:
                datos={'message':"ERROR: reporte No Encontrado"}
            return JsonResponse(datos)
        else:
            reportes = list(Reporte.objects.values())
            if len(reportes) > 0:
                datos={'message':"Success","reportes":reportes}
            else:
                datos={'message':"ERROR: reportes No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_reporte(descripcion_reporte=jd['descripcion_reporte'],productos_entregados_reporte=jd['productos_entregados_reporte'],productos_perdidos_reporte=jd['productos_perdidos_reporte'],productos_restantes_reporte=jd['productos_restantes_reporte'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_reporte):
        jd = json.loads(request.body)
        reportes = list(Reporte.objects.filter(id_reporte=id_reporte).values())
        if len(reportes) > 0:
            modificar_reporte(id_reporte=jd['id_reporte'],descripcion_reporte=jd['descripcion_reporte'],productos_entregados_reporte=jd['productos_entregados_reporte'],productos_perdidos_reporte=jd['productos_perdidos_reporte'],productos_restantes_reporte=jd['productos_restantes_reporte'],id_venta=jd['id_venta'],id_usuario=jd['id_usuario'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el reporte"}
        return JsonResponse(datos)

    def delete(self, request,id_reporte):
        reportes = list(Reporte.objects.filter(id_reporte=id_reporte).values())
        jd = json.loads(request.body)
        if len(reportes) > 0:
            eliminar_reporte(id_reporte=jd['id_reporte'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el reporte"}
        return JsonResponse(datos)

class ReporteViewset(viewsets.ModelViewSet):
    queryset = Reporte.objects.filter(estado_fila='1')
    serializer_class = ReporteSerializer


class ReporteHistoricoViewset(viewsets.ModelViewSet):
    queryset = Reporte.objects.all()
    serializer_class = ReporteHistoricoSerializer