from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt

import cx_Oracle
import json

# Create your views here.
def request_cliente_externo(rut_cliente_externo,contrasena_cliente_externo):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc("dbms_output.enable")
    cursor.callproc('CLIENTE_EXTERNO_LOGIN',[rut_cliente_externo,contrasena_cliente_externo,])
    statusVar = cursor.var(cx_Oracle.NUMBER)
    lineVar = cursor.var(cx_Oracle.DB_TYPE_CHAR)
    global data
    data=[]
    while True:
        cursor.callproc("dbms_output.get_line", (lineVar, statusVar))
        if statusVar.getvalue() != 0:
            
            break
        data.append(lineVar.getvalue())

    return data

class ClienteExternoAuthView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)


    def post(self, request):
        jd = json.loads(request.body)
        datos = request_cliente_externo(rut_cliente_externo=jd['rut_cliente_externo'],contrasena_cliente_externo=jd['contrasena_cliente_externo'])
        datos = list(datos[0].strip())
        return JsonResponse(datos,safe=False)


def request_cliente_interno(rut_cliente_interno,contrasena_cliente_interno):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc("dbms_output.enable")
    cursor.callproc('CLIENTE_INTERNO_LOGIN',[rut_cliente_interno,contrasena_cliente_interno,])
    statusVar = cursor.var(cx_Oracle.NUMBER)
    lineVar = cursor.var(cx_Oracle.DB_TYPE_CHAR)
    global data
    data=[]
    while True:
        cursor.callproc("dbms_output.get_line", (lineVar, statusVar))
        if statusVar.getvalue() != 0:
            
            break
        data.append(lineVar.getvalue())

    return data


class ClienteInternoAuthView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)


    def post(self, request):
        jd = json.loads(request.body)
        datos = request_cliente_interno(rut_cliente_externo=jd['rut_cliente_interno'],contrasena_cliente_interno=jd['contrasena_cliente_interno'])
        datos = list(datos[0].strip())
        return JsonResponse(datos,safe=False)



def request_proveedor(rut_proveedor,contrasena_proveedor):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc("dbms_output.enable")
    cursor.callproc('PROVEEDOR_LOGIN',[rut_proveedor,contrasena_proveedor,])
    statusVar = cursor.var(cx_Oracle.NUMBER)
    lineVar = cursor.var(cx_Oracle.DB_TYPE_CHAR)
    global data
    data=[]
    while True:
        cursor.callproc("dbms_output.get_line", (lineVar, statusVar))
        if statusVar.getvalue() != 0:
            
            break
        data.append(lineVar.getvalue())

    return data


class ProveedorAuthView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)


    def post(self, request):
        jd = json.loads(request.body)
        datos = request_proveedor(rut_proveedor=jd['rut_proveedor'],contrasena_proveedor=jd['contrasena_proveedor'])
        datos = list(datos[0].strip())
        return JsonResponse(datos,safe=False)



def request_transportista(rut_transportista,contrasena_transportista):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    cursor.callproc("dbms_output.enable")
    cursor.callproc('TRANSPORTISTA_LOGIN',[rut_transportista,contrasena_transportista,])
    statusVar = cursor.var(cx_Oracle.NUMBER)
    lineVar = cursor.var(cx_Oracle.DB_TYPE_CHAR)
    global data
    data=[]
    while True:
        cursor.callproc("dbms_output.get_line", (lineVar, statusVar))
        if statusVar.getvalue() != 0:
            
            break
        data.append(lineVar.getvalue())

    return data


class TransportistaAuthView(View):
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)


    def post(self, request):
        jd = json.loads(request.body)
        datos = request_proveedor(rut_transportista=jd['rut_transportista'],contrasena_transportista=jd['contrasena_transportista'])
        datos = list(datos[0].strip())
        return JsonResponse(datos,safe=False)