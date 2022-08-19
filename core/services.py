import requests
import json

def generate_request_tbk(url, body):
    try:
        response = requests.post(url, body, headers = { "Tbk-Api-Key-Id": "597055555532", "Tbk-Api-Key-Secret": "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", "Content-Type": "application/json"}, timeout=None)
        if response.status_code == 200:
            return response.json()
    except requests.exceptions.ConnectionError as e:
        response = "No hay respuesta" 
        return response

def get_initTrxTBK(monto):
    body = json.dumps({"buy_order": "ordencompra", "session_id": "sesion1234557545", "amount": monto , "return_url": "http://localhost:8000/tbkRes/" })
    url = "https://webpay3gint.transbank.cl/rswebpaytransaction/api/webpay/v1.0/transactions"
    response = generate_request_tbk(url, body)
    if response:
       return response

def get_status_trx(url, token_ws):
    try:
        response = requests.get(url+"/"+token_ws,  headers = { "Tbk-Api-Key-Id": "597055555532", "Tbk-Api-Key-Secret": "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", "Content-Type": "application/json"}, timeout=None)
        if response.status_code == 200:
            return response.json()
    except requests.exceptions.ConnectionError as e:
        response = "No hay respuesta"
        return response

def get_statusTBK(request):

    url = "https://webpay3gint.transbank.cl/rswebpaytransaction/api/webpay/v1.0/transactions/"
    token = request.POST['token_ws']
    response = token 
    try : 
        header = {'Tbk-Api-Key-Id': '597055555532',
            'Tbk-Api-Key-Secret': '579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C',
            'Content-Type': 'application/json'}
        autorizar = requests.put(url+token,headers=header).json()
        respuesta = requests.get(url+token,headers=header).json()
        resTrans = respuesta['vci']
        if (resTrans == 'TSY'):
            resTrans = 'Transacción Aprobada'
            resBool = True
        elif (resTrans == 'TSN'):
            resTrans = 'Autenticación Fallida'
            resBool = False
        elif (resTrans == 'TO'):
            resTrans = 'Tiempo máximo excedido para autenticación'
            resBool = False
        elif (resTrans == 'Autenticación abortada'):
            resTrans = 'Autenticación Fallida'
            resBool = False
        elif (resTrans == 'U3'):
            resTrans = 'Error interno en la autenticación'
            resBool = False
        elif (resTrans == 'NP'):
            resTrans = 'No Participa: Probable tarjeta extranjera'
            resBool = False
        elif (resTrans == 'ACS2'):
            resTrans = 'Autenticación fallida extranjera con tarjeta extranjera'
            resBool = False
        else:
            resTrans = 'Ha ocurrido un error con la autenticación'
            resBool = False
        status = respuesta ['status']
        idCompra = respuesta['buy_order']
        response = {'status':status,'idCompra':idCompra,'response':resTrans}

    except: 
        response = "ah ocurrido un problema"

    #response = get_status_trx(url, request.POST['token_ws'])
    if response:
       return response
