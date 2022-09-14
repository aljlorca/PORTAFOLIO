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
    url = 'http://127.0.0.1:8000/api/cliente_externo_auth/'+str(rut_cliente_externo)+'?format=json'
    payload = {}
    response = requests.post(url,json=payload)
    if response.status_code == 201:
        data={'message':'ERROR: 201'}
        return data
    if response.status_code == 200:
        data={'message':'Succes'}
    


