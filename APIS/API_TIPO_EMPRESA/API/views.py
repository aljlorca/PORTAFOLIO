from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import TipoEmpresa
from .serializers import TipoEmpresaSerializer,TipoEmpresaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_tipo_empresa(tipo_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('TIPO_EMPRESA_AGREGAR',[tipo_empresa,estado_fila,salida])
    return salida

def modificar_tipo_empresa(id_tipo_empresa,tipo_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('TIPO_EMPRESA_MODIFICAR',[id_tipo_empresa,tipo_empresa,salida])

def eliminar_tipo_empresa(id_tipo_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('TIPO_EMPRESA_ELIMINAR',[id_tipo_empresa,salida])

def lista_tipo_empresa():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('TIPO_EMPRESA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class TipoEmpresaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_tipo_empresa=0):
        if(id > 0):
            tipos=list(TipoEmpresa.objects.filter(id_tipo_empresa=id_tipo_empresa).values())
            if len(tipos) > 0:
                tipo = tipos[0]
                datos={'message':"Success","tipo_empresa":tipo}
            else:
                datos={'message':"ERROR: tipo empresa No Encontrada"}
            return JsonResponse(datos)
        else:
            tipos = list(TipoEmpresa.objects.values())
            if len(tipos) > 0:
                datos={'message':"Success","tipos_empresa":tipos}
            else:
                datos={'message':"ERROR: tipos de empresa No encontradas"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_tipo_empresa(tipo_empresa=jd['tipo_empresa'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_tipo_empresa):
        jd = json.loads(request.body)
        tipos = list(TipoEmpresa.objects.filter(id_tipo_empresa=id_tipo_empresa).values())
        if len(tipos) > 0:
            modificar_tipo_empresa(id_tipo_empresa=jd['id_tipo_empresa'],tipo_empresa=jd['tipo_empresa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el tipo de empresa"}
        return JsonResponse(datos)

    def delete(self, request,id_tipo_empresa):
        tipos = list(TipoEmpresa.objects.filter(id_tipo_empresa=id_tipo_empresa).values())
        jd = json.loads(request.body)
        if len(tipos) > 0:
            eliminar_tipo_empresa(id_tipo_empresa=jd['id_tipo_empresa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el tipo de empresa"}
        return JsonResponse(datos)

class TipoEmpresaViewset(viewsets.ModelViewSet):
    queryset = TipoEmpresa.objects.filter(estado_fila='1')
    serializer_class = TipoEmpresaSerializer


class TipoEmpresaHistoricoViewset(viewsets.ModelViewSet):
    queryset = TipoEmpresa.objects.all()
    serializer_class = TipoEmpresaHistoricoSerializer