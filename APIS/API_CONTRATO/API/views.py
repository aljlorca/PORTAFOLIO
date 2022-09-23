from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Contrato
from .serializers import Contrato, ContratoSerializer
from rest_framework import viewsets
import json
# Create your views here.

def agregar_contrato(documento_contrato,fecha_contrato,rut_cliente_externo,rut_administrador,tipo_contrato):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CONTRATO_AGREGAR',[documento_contrato,fecha_contrato,rut_cliente_externo,rut_administrador,tipo_contrato])

def modificar_contrato(id_contrato,documento_contrato,fecha_contrato,rut_cliente_externo,rut_administrador,tipo_contrato):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CONTRATO_MODIFICAR',[id_contrato,documento_contrato,fecha_contrato,rut_cliente_externo,rut_administrador,tipo_contrato])

def eliminar_contrato(id_contrato):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc('CONTRATO_ELIMINAR',[id_contrato])

def listar_contrato():
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()
    cursor.callproc('CONTRATO_LISTAR', [out_cur])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista

class ContratoViewset(viewsets.ModelViewSet):
    queryset = Contrato.objects.all()
    serializer_class = ContratoSerializer

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
        jd = json.loads(request.body)
        agregar_contrato(documento_contrato=jd['documento_contrato'],fecha_contrato=jd['fecha_contrato'],rut_cliente_externo=jd['rut_cliente_externo'],rut_administrador=jd['rut_administrador'],tipo_contrato=jd['tipo_contrato'],)
        datos={'message':'Success'}
        return JsonResponse(datos)
    
    def put(self,request,id_contrato):
        jd = json.loads(request.body)
        contratos = list(Contrato.objects.filter(id_contrato=id_contrato).values())
        if len(contratos)>0:
            modificar_contrato(id_contrato=jd['id_contrato'],documento_contrato=jd['documento_contrato'],fecha_contrato=jd['fecha_contrato'],rut_cliente_externo=jd['rut_cliente_externo'],rut_administrador=jd['rut_administrador'],tipo_contrato=jd['tipo_contrato'],)
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: Contrato NO fue posible actualizar sus datos'}
        return JsonResponse(datos)
    
    def delete(self,request,id_contrato):
        contratos = list(Contrato.objects.filter(id_contrato=id_contrato).values())
        if len(contratos) > 0:
            eliminar_contrato(id_contrato)
            datos={'message':'Success'}
        else:
            datos={'message':'ERROR: NO fue posible eliminar el Contrato'}
        return JsonResponse(datos)

