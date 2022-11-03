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
def agregar_empresa(duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,id_region,id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('EMPRESA_AGREGAR',[duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,id_region,id_pais,estado_fila,salida])
    return round(salida.getvalue())

def modificar_empresa(duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,id_region,id_pais):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('EMPRESA_MODIFICAR',[duns_empresa,razon_social_empresa,direccion_empresa,giro_empresa,id_tipo_empresa,id_ciudad,id_region,id_pais,salida])
    return round(salida.getvalue())

def eliminar_empresa(id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('EMPRESA_ELIMINAR',[id_empresa,salida])
    return round(salida.getvalue())

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
        if(id_empresa > 0):
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
        try:
            jd = json.loads(request.body)
            try: 
                salida = agregar_empresa(duns_empresa=jd['duns_empresa'],razon_social_empresa=jd['razon_social_empresa'],direccion_empresa=jd['direccion_empresa'],giro_empresa=jd['giro_empresa'],id_tipo_empresa=jd['id_tipo_empresa'],id_ciudad=jd['id_ciudad'],id_region=jd['id_region'],id_pais=jd['id_pais'])
                if salida == 1:
                    datos = {'message':'Success'}
                    print(datos)
                elif salida == 0:
                    datos = {'message':'ERROR: no fue posible registrar la empresa'}
                    print(datos)
            except:
                datos = {'message':'ERROR: Validar datos'}
                print(datos)
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)
        

    def put(self, request,id_empresa):
        try:
            jd = json.loads(request.body)
            empresas = list(Empresa.objects.filter(id_empresa=id_empresa).values())
            if len(empresas) > 0:
                try:
                    salida = modificar_empresa(duns_empresa=jd['duns_empresa'],razon_social_empresa=jd['razon_social_empresa'],direccion_empresa=jd['direccion_empresa'],giro_empresa=jd['giro_empresa'],id_tipo_empresa=jd['id_tipo_empresa'],id_ciudad=jd['id_ciudad'],id_region=jd['id_region'],id_pais=jd['id_pais'])
                    if salida == 1:
                        datos={'message':"Success"}
                    elif salida == 0:
                        datos={'message':'ERROR: no fue posible modificar la empresa'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':"ERROR: No se encuentra la empresa"}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)

    def delete(self, request,id_empresa):
        empresas = list(Empresa.objects.filter(id_empresa=id_empresa).values())
        if len(empresas) > 0:
            try:
                salida = eliminar_empresa(id_empresa)
                if salida == 1:
                    datos={'message':"Success"}
                elif salida == 0:
                    datos={'message':'ERROR: no fue posible eliminar la empresa'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':"ERROR: no fue posible eliminar la empresa"}
        return JsonResponse(datos)

class EmpresaViewset(viewsets.ModelViewSet):
    queryset = Empresa.objects.filter(estado_fila='1')
    serializer_class = EmpresaSerializer


class EmpresaHistoricoViewset(viewsets.ModelViewSet):
    queryset = Empresa.objects.all()
    serializer_class = EmpresaHistoricoSerializer