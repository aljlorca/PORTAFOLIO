from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from django.http import HttpResponse
from .models import Contrato
from .serializers import ContratoSerializer,ContratoHistoricoSerializer
from rest_framework import viewsets
import json
import cx_Oracle
# Create your views here.

def agregar_contrato(documento_contrato,fecha_contrato,tipo_contrato,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    estado_fila = '1'
    cursor.callproc('CONTRATO_AGREGAR',[documento_contrato,fecha_contrato,tipo_contrato,id_empresa,estado_fila,salida])
    return round(salida.getvalue())

def modificar_contrato(id_contrato,documento_contrato,fecha_contrato,tipo_contrato,id_empresa):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CONTRATO_MODIFICAR',[id_contrato,documento_contrato,fecha_contrato,tipo_contrato,id_empresa,salida])
    return round(salida.getvalue())

def eliminar_contrato(id_contrato):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    salida = cursor.var(cx_Oracle.NUMBER)
    cursor.callproc('CONTRATO_ELIMINAR',[id_contrato,salida])
    return round(salida.getvalue())

def listar_contrato():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CONTRATO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

class ContratoView(View):
    
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def get(self,request,id_contrato=0):
        if(id_contrato>0):
            contratos=list(Contrato.objects.filter(id_contrato=id_contrato).values())
            if len(contratos) > 0:
                contrato = contratos[0]
                datos={'message':'Success','Contrato':contrato}
            else:
                datos={'message':'Error: Contrato NO Encontrado'}
            return JsonResponse(datos)
        else:
            contratos = list(Contrato.objects.values())
            if len(contratos)>0:
                datos={'message':'Success','Contratos':contratos}
            else:
                datos={'message':'Error: Contratos NO Encontrados'}
            return JsonResponse(datos)
    
    def post(self,request):
        try:
            jd = json.loads(request.body)
            try: 
                salida = agregar_contrato(documento_contrato=jd['documento_contrato'],fecha_contrato=jd['fecha_contrato'],tipo_contrato=jd['tipo_contrato'],id_empresa=jd['id_empresa'])
                if salida == 1:
                    datos={'message':'Success'}
                elif salida == 0:
                    datos={'message':'ERROR: no fue posible agregar el contrato'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        except:
            datos = {'message':'ERORR: Json invalido'}

        return JsonResponse(datos)
    
    def put(self,request,id_contrato):
        try:
            jd = json.loads(request.body)
            contratos = list(Contrato.objects.filter(id_contrato=id_contrato).values())
            if len(contratos)>0:
                try:
                    salida = modificar_contrato(id_contrato=jd['id_contrato'],documento_contrato=jd['documento_contrato'],fecha_contrato=jd['fecha_contrato'],tipo_contrato=jd['tipo_contrato'],id_empresa=jd['id_empresa'])
                    if salida == 1:
                        datos={'message':'Success'}
                    elif salida == 0:
                        datos={'message':'ERROR: no fue posible modificar el contrato'}
                except:
                    datos = {'message':'ERROR: Validar datos'}
            else:
                datos={'message':'ERROR: Contrato NO encontrado'}
        except:
            datos = {'message':'ERORR: Json invalido'}
        
        return JsonResponse(datos)
    
    def delete(self,request,id_contrato):
        contratos = list(Contrato.objects.filter(id_contrato=id_contrato).values())
        if len(contratos) > 0:
            try:
                salida = eliminar_contrato(id_contrato)
                if salida == 1:
                    datos={'message':'Success'}
                elif salida == 0:
                    datos={'message':'ERROR: no fue posible eliminar el contrato'}
            except:
                datos = {'message':'ERROR: Validar datos'}
        else:
            datos={'message':'ERROR: NO fue posible eliminar el Contrato'}
        return JsonResponse(datos)


class ContratoViewset(viewsets.ModelViewSet):
    queryset = Contrato.objects.filter(estado_fila='1')
    serializer_class = ContratoSerializer

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
    
    def post(self, request, *args, **kwargs):
        try:
            id_contrato = request.data['id_contrato']
            documento_contrato = request.data['documento_contrato']
            fecha_contrato = request.data['fecha_contrato']
            tipo_contrato = request.data['tipo_contrato']
            id_empresa = request.data['id_empresa']
            estado_fila = '1'
            Contrato.objects.create(id_contrato=id_contrato, documento_contrato=documento_contrato,fecha_contrato=fecha_contrato,tipo_contrato=tipo_contrato,id_empresa=id_empresa,estado_fila=estado_fila)
            datos = {'message': 'Success'}
        except:
            datos = {'message':'ERROR: Validar datos'}

        return HttpResponse(datos, status=200)

    def put(self, request, *args, **kwargs):
        try:
            id_contrato = request.data['id_contrato']
            documento_contrato = request.data['documento_contrato']
            fecha_contrato = request.data['fecha_contrato']
            tipo_contrato = request.data['tipo_contrato']
            id_empresa = request.data['id_empresa']
            estado_fila = '1'
            Contrato.objects.update(id_contrato=id_contrato, documento_contrato=documento_contrato,fecha_contrato=fecha_contrato,tipo_contrato=tipo_contrato,id_empresa=id_empresa,estado_fila=estado_fila)
            datos = {'message': 'Success'}
        except:
            datos = {'message':'ERROR: Validar datos'}
        
        return HttpResponse(datos, status=200)

    def delete(self, request, *args, **kwargs):
        try:
            id_contrato = request.data['id_contrato']
            salida = eliminar_contrato(id_contrato)
            if salida == 1:
                datos = {'message':'Success'}
            elif salida == 0:
                datos = {'message':'ERROR: no fue posible eliminar el contrato'}
        except:
            datos = {'message':'ERROR: Validar datos'}
        return HttpResponse(datos, status=200)

class ContratoHistoricoViewset(viewsets.ModelViewSet):
    queryset = Contrato.objects.all()
    serializer_class = ContratoHistoricoSerializer