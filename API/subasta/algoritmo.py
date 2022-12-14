import requests 
import json

##subastas a borrar
def subasta_venta(id_venta):
    url = 'http://127.0.0.1:8000/api_subasta/subasta_carga/'+str(id_venta)
    response = requests.get(url)
    content = json.loads(response.content)
    return content


def subasta_delete(id_subasta):
    url = 'http://127.0.0.1:8000/api_subasta/subasta_old/'+str(id_subasta)
    response = requests.delete(url)
    content = json.loads(response.content)
    return content

def venta_reporte(id_venta):
    url = 'http://127.0.0.1:8000/api_venta/venta_reporte/'+str(id_venta)
    response = requests.post(url)
    content = json.loads(response.content)
    return content



def rechazar_restantes(id_venta):
    try:
        subastas = subasta_venta(id_venta)
        cont = 0
        for i in subastas:

            subasta = subastas[cont]
            subasta_delete(subasta['id_subasta'])
            
            cont = cont+1
        venta_reporte(id_venta)

    except:
        pass
