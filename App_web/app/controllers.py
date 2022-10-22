import requests
import json
from django.contrib.sessions import *
from django.http import HttpResponse


#AUTH CONTROLLERS 
def login_controller(correo,contrasena):
    url = 'http://127.0.0.1:8006/api/usuario_auth/'
    body = {"correo_usuario": correo,"contrasena_usuario": contrasena}
    response = requests.post(url,json=body)

    if response.status_code == 200:
        content = json.loads(response.content)
        return content


def logout_controller(request):
    try:
        del request.session['username']
        del request.session['cargo']
        del request.session['email']
        del request.session['company']

    except KeyError:
        pass
    return HttpResponse("Has cerrado Session")

def get_session(request):
    try:
        usuario=request.session['username']
        cargo=request.session['cargo']
        correo=request.session['email']
        empresa=request.session['company']
        id_usuario = request.session['id_user']
        
        data={
            'cargo':cargo,
            'usuario':usuario,
            'correo':correo,
            'empresa':empresa,
            'id_user':id_usuario}
    except:
        data={'cargo':'Visita'}
        
    return data



#PRODUCTOS CONTROLLERS
def crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,estado_fila,id_usuario): 

    url= 'http://127.0.0.1:8010/api/producto/'
    files = {"imagen_producto":open(imagen_producto, 'rb')}
    body ={"id_producto":id_producto,"nombre_producto":nombre_producto,"cantidad_producto":cantidad_producto,"precio_producto":precio_producto,"id_calidad":id_calidad,"saldo_producto":saldo_producto,"estado_fila":estado_fila,"id_usuario":id_usuario}
    response = requests.post(url,data=body, files=files)
    return response

def productos_get():
    url='http://127.0.0.1:8010/api/producto/'
    try: 
     r = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if r.status_code == 200:
        content = json.loads(r.content)
        return content

def producto_get_id(id):
    url='http://127.0.0.1:8010/api/producto/'+str(id)
    try: 
     response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        data = 'ERROR: Producto no encontrado'
        return data

#SUBASTA CONTROLLERS
def subasta_controller(monto,id_venta,id_usuario):
    url = 'http://127.0.0.1:8014/api/subasta_old/'
    body = {"monto_subasta": monto,"id_venta":id_venta,"id_usuario":id_usuario}
    response = requests.post(url,json=body)
    print (response)

#PEDIDO CONTROLLERS
def pedido_get():
    url = 'http://127.0.0.1:8008/api/pedido/'
    try: 
     r = requests.get(url)
    except:
        data = {'message':'error de conexion'}
        return data
    if r.status_code == 200:
        content = json.loads(r.content)
        return content

#Postulacion Controllers       
def ventas_get():
    url='http://127.0.0.1:8017/api/venta/'
    r = requests.get(url)
    if r.status_code == 200:
        content = json.loads(r.content)
        return content
    
#USUARIO CONTROLLERS
def usuario_get_id(id):
    url = 'http://127.0.0.1:8016/api/usuario/'+str(id)
    try: 
     response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        data = 'ERROR: Usuario no encontrado'
        return data

#PAIS CONTROLLER
def get_pais_id(id):
    url = 'http://127.0.0.1:8007/api/pais/'+str(id)
    try: 
     response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        data = 'ERROR: Pais no encontrado'
        return data
    
#Ciudad CONTROLLER
def get_ciudad_id(id):
    url = 'http://127.0.0.1:8003/api/ciudad/'+str(id)
    try: 
     response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        data = 'ERROR: Ciudad no encontrada'
        return data
#Region CONTROLLER
def get_region_id(id):
    url = 'http://127.0.0.1:8011/api/region/'+str(id)
    try: 
     response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        data = 'ERROR: Region no encontrada'
        return data   
    