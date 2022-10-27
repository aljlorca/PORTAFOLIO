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
    return round(salida.getvalue())

def modificar_tipo_empresa(id_tipo_empresa,tipo_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('TIPO_EMPRESA_MODIFICAR',[id_tipo_empresa,tipo_empresa,salida])
    return round(salida.getvalue())

def eliminar_tipo_empresa(id_tipo_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('TIPO_EMPRESA_ELIMINAR',[id_tipo_empresa,salida])
    return round(salida.getvalue())

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
        if(id_tipo_empresa > 0):
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
        try:
            jd = json.loads(request.body)
        except:
            datos = {'message':'ERORR: Json invalido'}
        try:
            salida  = agregar_tipo_empresa(tipo_empresa=jd['tipo_empresa'])
            if salida == 1:
                datos = {'message':'Success'}
            elif salida == 0:
                datos = {'message':'ERORR: no fue posible agregar el tipo de empresa'}
        except:
            datos = {'message':'ERROR: Validar datos'}
        return JsonResponse(datos)
        

    def put(self, request,id_tipo_empresa):
        try:
            jd = json.loads(request.body)
        except:
            datos = {'message':'ERORR: Json invalido'}
        tipos = list(TipoEmpresa.objects.filter(id_tipo_empresa=id_tipo_empresa).values())
        if len(tipos) > 0:
            try:
                salida = modificar_tipo_empresa(tipo_empresa=jd['tipo_empresa'])
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible modificar el tipo de empresa'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: No se encuentra el tipo de empresa"}
        return JsonResponse(datos)

    def delete(self, request,id_tipo_empresa):
        tipos = list(TipoEmpresa.objects.filter(id_tipo_empresa=id_tipo_empresa).values())
        if len(tipos) > 0:
            try:
                salida = eliminar_tipo_empresa(id_tipo_empresa)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos = {'message':'ERORR: no fue posible eliminar el tipo de empresa '}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: No se encuentra el tipo de empresa"}
        return JsonResponse(datos)

class TipoEmpresaViewset(viewsets.ModelViewSet):
    queryset = TipoEmpresa.objects.filter(estado_fila='1')
    serializer_class = TipoEmpresaSerializer


class TipoEmpresaHistoricoViewset(viewsets.ModelViewSet):
    queryset = TipoEmpresa.objects.all()
    serializer_class = TipoEmpresaHistoricoSerializer