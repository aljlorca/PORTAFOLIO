import requests
import json
from .models import Producto

def login_controller(correo,contrasena):
    url = 'http://127.0.0.1:8004/api/usuario_auth/'
    body = {"correo_usuario": correo,"contrasena_usuario": contrasena}
    response = requests.post(url,json=body)

    if response.status_code == 200:
        content = json.loads(response.content)
        if content['message'] == 'Success':
            return content
        else:
            data ='ERROR:usuario no encontrado'
            return data
    if response.status_code == 404:
        data = 'ERRROR: usuario no encontrado'
        return data

def crear_producto(id_producto,nombre_producto,cantidad_producto,precio_producto,imagen_producto,id_calidad,saldo_producto,estado_fila,id_usuario):\
    
    url= 'http://127.0.0.1:8010/api/producto/'
    body ={"id_producto":id_producto,"nombre_producto":nombre_producto,"cantidad_producto":cantidad_producto,"precio_producto":precio_producto,"imagen_producto":(open(imagen_producto,'rb')),"id_calidad":id_calidad,"saldo_producto":saldo_producto,"estado_fila":estado_fila,"id_usuario":id_usuario}
    response = requests.post(url, files=body, )

def postulacion_controller(descripcion,estado,id_venta,id_usuario):
    url = 'http://127.0.0.1:8009/api/postulacion_old'
    body = {"descripcion_postulacion": descripcion,"estado_postulacion": estado,"id_venta": id_venta,"id_usuario": id_usuario}
    response = requests.post(url,json=body)
    print (response)


