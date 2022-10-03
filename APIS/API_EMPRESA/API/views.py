from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Empresa
from .serializers import EmpresaSerializer,EmpresaHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.
def agregar_empresa(rut_empresa, duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('EMPRESA_AGREGAR',[rut_empresa, duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,estado_fila,salida])
    return salida

def modificar_empresa(rut_empresa, duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('EMPRESA_MODIFICAR',[rut_empresa, duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,salida])

def eliminar_empresa(id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('EMPRESA_ELIMINAR',[id_empresa,salida])

def lista_empresa():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('EMPRESA_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista
    

class EmpresaView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, id_empresa=0):
        if(id > 0):
            empresas=list(Empresa.objects.filter(id_empresa=id_empresa).values())
            if len(empresas) > 0:
                empresa = empresas[0]
                datos={'message':"Success","empresa":empresa}
            else:
                datos={'message':"ERROR: Cargo No Encontrado"}
            return JsonResponse(datos)
        else:
            empresas = list(Empresa.objects.values())
            if len(empresas) > 0:
                datos={'message':"Success","empresas":empresas}
            else:
                datos={'message':"ERROR: empresas No encontrados"}
            return JsonResponse(datos)

    def post(self, request):
        jd = json.loads(request.body)
        agregar_empresa(rut_empresa=jd['rut_empresa'],duns_empresa=jd['duns_empresa'],razon_social_empresa=jd['razon_social_empresa'],direccion_empresa=jd['direccion_empresa'],giro_empresa=jd['giro_empresa'],id_tipo_empresa=jd['id_tipo_empresa'],id_ciudad=jd['id_ciudad'])
        datos = {'message':'Success'}
        return JsonResponse(datos)
        

    def put(self, request,id_empresa):
        jd = json.loads(request.body)
        empresas = list(Empresa.objects.filter(id_empresa=id_empresa).values())
        if len(empresas) > 0:
            modificar_empresa(rut_empresa=jd['rut_empresa'],duns_empresa=jd['duns_empresa'],razon_social_empresa=jd['razon_social_empresa'],direccion_empresa=jd['direccion_empresa'],giro_empresa=jd['giro_empresa'],id_tipo_empresa=jd['id_tipo_empresa'],id_ciudad=jd['id_ciudad'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: No se encuentra el usuario"}
        return JsonResponse(datos)

    def delete(self, request,id_empresa):
        empresas = list(Empresa.objects.filter(id_empresa=id_empresa).values())
        jd = json.loads(request.body)
        if len(empresas) > 0:
            eliminar_empresa(id_empresa=jd['id_empresa'])
            datos={'message':"Success"}
        else:
            datos={'message':"ERROR: no fue posible eliminar el cargo"}
        return JsonResponse(datos)

class EmpresaViewset(viewsets.ModelViewSet):
    queryset = Empresa.objects.filter(usuario_vigente='1')
    serializer_class = EmpresaSerializer


class EmpresaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Empresa.objects.all()
    serializer_class = EmpresaHistoricoSerializer