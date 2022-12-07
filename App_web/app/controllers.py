import requests
import json
from django.contrib.sessions import *
from django.http import HttpResponse
import datetime


#AUTH CONTROLLERS 
def login_controller(correo,contrasena):
    url = 'http://127.0.0.1:8000/api_login/usuario_auth/'
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
        del request.session['carga']

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
def crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,estado_fila,id_usuario,descripcion_producto): 

    url= 'http://127.0.0.1:8000/api_producto/producto/'
    files = {"imagen_producto":open(imagen_producto, 'rb')}
    body ={"id_producto":id_producto,"nombre_producto":nombre_producto,"cantidad_producto":cantidad_producto,"precio_producto":precio_producto,"id_calidad":id_calidad,"saldo_producto":saldo_producto,"estado_fila":estado_fila,"id_usuario":id_usuario,"descripcion_producto":descripcion_producto}
    response = requests.post(url,data=body, files=files)
    return response

def productos_get():
    url='http://127.0.0.1:8000/api_producto/producto/'
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def producto_get_id(id):
    url='http://127.0.0.1:8000/api_producto/producto/'+str(id)
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

def producto_delete(id):
    url='http://127.0.0.1:8000/api_producto/producto_old/'+str(id)
    try: 
        response = requests.delete(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 201:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        data = 'ERROR: Producto no encontrado'
        return data

#SUBASTA CONTROLLERS
def subasta_post(monto,id_venta,id_usuario):
    url = 'http://127.0.0.1:8000/api_subasta/subasta_old/'
    body = {"monto_subasta": monto,"id_venta":id_venta,"id_usuario":id_usuario}
    try:
        response = requests.post(url,json=body)
    except: 
        data = 'error de conexion'
        return data

    if response.status_code == 201:
        content = json.loads(response.content)
        return content['id_subasta']

def subasta_get():
    url='http://127.0.0.1:8000/api_subasta/subasta/'
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def subasta_get_id(id):
    url='http://127.0.0.1:8000/api_subasta/subasta/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def subasta_get_venta(id):
    url='http://127.0.0.1:8000/api_subasta/subasta_venta/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def subasta_delete(id):
    url='http://127.0.0.1:8000/api_subasta/subasta_old/'+str(id)
    try: 
        response = requests.delete(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 201:
        content = json.loads(response.content)
        return content

def subasta_venta_usuario(id):
    url='http://127.0.0.1:8000/api_subasta/subasta_venta_usuario/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def subasta_aceptada(id):
    url='http://127.0.0.1:8000/api_subasta/subasta_aceptada/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

#PEDIDO CONTROLLERS
def pedido_get():
    url = 'http://127.0.0.1:8000/api_pedido/pedido/'
    try: 
        response = requests.get(url)
    except:
        data = {'message':'error de conexion'}
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def pedido_post(descripcion, fecha_sla,id_usuario):
    url="http://127.0.0.1:8000/api_pedido/pedido_old/"
    body = {"descripcion_pedido": descripcion,"fecha_sla_pedido":fecha_sla,"id_usuario":id_usuario}
    try: 
        response = requests.post(url,json=body)
    except:
        data = {'message':'error de conexion'}
        return data
    if response.status_code == 201:
        content = json.loads(response.content)
        return content

#USUARIO CONTROLLERS
def usuario_get_id(id):
    url = 'http://127.0.0.1:8000/api_usuario/usuario/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        content = json.loads(response.content)
        return data 

#Postulacion CONTROLLERS
def Postulacion_controller(descripcion_postulacion,estado_postulacion,id_venta,id_usuario,id_producto):
    url = 'http://127.0.0.1:8000/api_postulacion/postulacion_old/'
    body = {"descripcion_postulacion": descripcion_postulacion,"estado_postulacion":estado_postulacion,"id_venta":id_venta,"id_usuario":id_usuario,"id_producto":id_producto}
    try:
        response = requests.post(url,json=body)
    except:
        response = {'error':'Tenemos problemas en estos momentos'}
    return response

def postulacion_aceptada(id):
    url='http://127.0.0.1:8000/api_postulacion/postulacion_aceptada/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
#Venta Controllers       
def ventas_get():
    url='http://127.0.0.1:8000/api_venta/venta/'
    response = requests.get(url)
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

def Ventas_get_id(id):
    url = 'http://127.0.0.1:8000/api_venta/venta/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        content = json.loads(response.content)
        return content

def venta_cliente_aceptar(id):
    url = 'http://127.0.0.1:8000/api_venta/venta_cliente/'+str(id)
    body = {"estado_venta":"Aceptada"}
    try:
        response = requests.put(url,body)
    except:
        return 'error de conexion'
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        content = json.loads(response.content)
        return content
    if response.status_code == 500:
        content = json.loads(response.content)
        return content

def venta_cliente_rechazar(id):
    url = 'http://127.0.0.1:8000/api_venta/venta_cliente/'+str(id)
    body = {"estado_venta":"Rechazada"}
    try:
        response = requests.put(url,body)
    except:
        return 'error de conexion'
    if response.status_code == 200:
        content = json.loads(response.content)
        return content
    if response.status_code == 404:
        content = json.loads(response.content)
        return content
    if response.status_code == 500:
        content = json.loads(response.content)
        return content

#CARGA CONTROLLERS 
def carga_post(capacidad,tamano,refrigeracion,id_usuario,id_subasta):
    url="http://127.0.0.1:8000/api_carga/carga_old/"
    body ={"capacidad_carga": str(capacidad),"refrigeracion_carga": str(refrigeracion),"tamano_carga": str(tamano),"id_subasta":id_subasta ,"id_usuario": id_usuario}
    try: 
        response = requests.post(url,json=body)
    except:
        data = {'message':'error de conexion'}
        return data
    if response.status_code == 201:
        content = json.loads(response.content)
        return content

#CALIDAD CONTROLLERS
def calidad_get():
    url="http://127.0.0.1:8000/api_calidad/calidad/"
    try: 
        response = requests.get(url)
    except:
        data = {'message':'error de conexion'}
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        return content

#TBK 
def generate_request_tbk(url, body):
    try:
        response = requests.post(url, body, headers = { "Tbk-Api-Key-Id": "597055555532", "Tbk-Api-Key-Secret": "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", "Content-Type": "application/json"}, timeout=None)
        if response.status_code == 200:
            return response.json()
    except:
        response = "No hay respuesta" 
        return response

def get_initTrxTBK(monto, id_usuario):
    fecha_hoy = datetime.datetime.now()
    fecha=fecha_hoy.strftime("%d%m%y%H%M%S")
    fecha_session=fecha_hoy.strftime("%d%m%y%H%M")
    orden= id_usuario+'_'+fecha
    session = id_usuario+'_'+fecha_session
    body = json.dumps({"buy_order": orden, "session_id": session, "amount": monto , "return_url": "http://127.0.0.1:3000/tbk_respuesta/"})
    url = "https://webpay3gint.transbank.cl/rswebpaytransaction/api/webpay/v1.2/transactions"
    response = generate_request_tbk(url, body)
    if response:
        return response

def get_statusTBK(token):
    header = {'Tbk-Api-Key-Id': '597055555532','Tbk-Api-Key-Secret': '579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C','Content-Type': 'application/json'}
    url = "https://webpay3gint.transbank.cl/rswebpaytransaction/api/webpay/v1.2/transactions/"+token
    try: 
        autorizar = requests.put(url,headers=header).json()
        try:    
            if autorizar['error_message']=='Transaction has an invalid finished state: aborted':
                return 'error transaccion abortada'
        except:
            try:
                respuesta = requests.get(url,headers=header).json()
                return respuesta
            except:
                return 'tuvimos un problema al obtener su transaccion'
    except: 
        return "Tenemos problemas en estos momentos"

#CARRITO CONTROLLER
def carrito_post(monto,id_usuario):
    url = 'http://127.0.0.1:8000/api_carrito/carrito_old/'
    body = {"monto_carrito": monto,"id_producto": None,"id_usuario": id_usuario}
    try: 
        response = requests.post(url,json=body)
    except:
        data = {'message':'error de conexion'}
        return data
    if response.status_code == 201:
        content = json.loads(response.content)
        return content


def carrito_get_id(id):
    url = 'http://127.0.0.1:8000/api_carrito/carrito_user/'+str(id)
    try: 
        response = requests.get(url)
    except:
        data = 'error de conexion'
        return data
    if response.status_code == 200:
        content = json.loads(response.content)
        try:
            carrito=content['carritos']
            return carrito
        except:
            return content
    if response.status_code == 404:
        data = 'ERROR: Usuario no encontrado'
        return data

#REPORTE
def reporte_post(descripcion_reporte,productos_entregados_reporte,productos_perdidos_reporte,productos_restantes_reporte,id_venta,id_usuario):
    url = 'http://127.0.0.1:8000/api_reporte/reporte_old/'
    body = {"descripcion_reporte": descripcion_reporte,"productos_entregados_reporte": productos_entregados_reporte,"productos_perdidos_reporte": productos_perdidos_reporte,"productos_restantes_reporte":productos_restantes_reporte,"id_venta":id_venta,"id_usuario":id_usuario}
    try: 
        response = requests.post(url,json=body)
    except:
        data = {'message':'error de conexion'}
        return data
    if response.status_code == 201:
        content = json.loads(response.content)
        return content