import json, requests



def pedido_get():
    url = 'http://127.0.0.1:8008/api/pedido/'
    r = requests.get(url)
    if r.status_code == 200:
        content = json.loads(r.content)
        return content