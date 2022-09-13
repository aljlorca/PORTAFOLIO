import requests


def generate_request(url, params={}):
    try:
        response = requests.get(url,params=params)
        if response.status_code==200:
            return response.json()
    except requests.exceptions.ConnectionError as e:
        response = 'Error : no existe respuesta del servidor'
        return response

def get_cliente_externo_rut(rut_cliente_externo):
    url = 'http://127.0.0.1:8001/api/categoria/'
    payload = {'rut_cliente_externo':rut_cliente_externo}
    response = requests.post(url,json=payload)
    if response.status_code == 201:
        return response