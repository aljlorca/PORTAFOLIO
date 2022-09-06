import requests


def generate_request(url, params={}):
    try:
        response = requests.get(url,params=params)
        if response.status_code==200:
            return response.json()
    except requests.exceptions.ConnectionError as e:
        response = 'Error : no existe respuesta del servidor'
        return response

def get_administradores():
    response = generate_request('')
    if response:
        return response

def get_administrador_rut(rut):
    url = ''
    payload = {'rut_administrador':rut}
    response = requests.post(url,json=payload)
    if response.status_code == 201:
        return response
