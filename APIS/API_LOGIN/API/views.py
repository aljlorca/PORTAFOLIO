from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from rest_framework import viewsets
from rest_framework import serializers

import cx_Oracle
import json

# Create your views here.
def request_auth(rut_cliente_externo,contrasena_cliente_externo):
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
        datos = request_auth(rut_cliente_externo=jd['rut_cliente_externo'],contrasena_cliente_externo=jd['contrasena_cliente_externo'])
        datos = datos[0].strip()
        return JsonResponse(datos,safe=False)



    