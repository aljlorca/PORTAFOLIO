import requests
import json
from django.contrib.sessions import *
from django.http import HttpResponse

def login_controller(request,correo,contrasena):
    url = 'http://127.0.0.1:8006/api/usuario_auth/'
    body = {"correo_usuario": correo,"contrasena_usuario": contrasena}
    response = requests.post(url,json=body)

    if response.status_code == 200:
        content = json.loads(response.content)
        if content['message'] == 'Success':
            respt = content['usuario']
            request.session['user'] = respt
            return content
        else:
            data ='ERROR:usuario no encontrado'
            return data
    if response.status_code == 404:
        data = 'ERRROR: bad request'
        return data

def logout_controller(request):
    try:
        del request.session['user']
    except KeyError:
        pass
    return HttpResponse("Has cerrado Session")

def crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,estado_fila,id_usuario): 

    url= 'http://127.0.0.1:8010/api/producto/'
    files = {"imagen_producto":open(imagen_producto, 'rb')}
    body ={"id_producto":id_producto,"nombre_producto":nombre_producto,"cantidad_producto":cantidad_producto,"precio_producto":precio_producto,"id_calidad":id_calidad,"saldo_producto":saldo_producto,"estado_fila":estado_fila,"id_usuario":id_usuario}
    response = requests.post(url,data=body, files=files)
    return response

def subasta_controller(monto,id_venta,id_usuario):
    url = 'http://127.0.0.1:8014/api/subasta_old/'
    body = {"monto_subasta": monto,"id_venta":id_venta,"id_usuario":id_usuario}
    response = requests.post(url,json=body)
    print (response)



