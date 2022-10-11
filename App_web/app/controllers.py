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
            usuario = respt[0]
            cargo = respt[1]
            correo = respt[2]
            fecha = respt[3]
            print(usuario,cargo,correo,fecha)
        else:
            data ='usuario no encontrado'
            print(data)


    if response.status_code == 404:
        data = {'message':'usuario no encontrado'}
        print(data)
     
    