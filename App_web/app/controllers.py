import requests
import json

def login_controller(correo,contrasena):
    url = 'http://127.0.0.1:8004/api/usuario_auth/'
    body = {"correo_usuario": correo,"contrasena_usuario": contrasena}
    response = requests.post(url,json=body)

    if response.status_code == 200:
        content = json.loads(response.content)
        if content['message'] == 'Success':
            respt = content['usuario']
            return respt
        else:
            data ='ERROR:usuario no encontrado'
            return data


    if response.status_code == 404:
        data = 'ERRROR: usuario no encontrado'
        return data
        


