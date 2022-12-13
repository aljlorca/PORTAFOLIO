import requests
import json

def get_subasta(id_venta):
    url = 'http://127.0.0.1:8000/api_subasta/subasta_aceptada/'+str(id_venta)
    response = requests.get(url)
    content = json.loads(response.content)
    return content

def get_postulacion(id_venta):
    url = 'http://127.0.0.1:8000/api_postulacion/postulacion_aceptada/'+str(id_venta)
    response = requests.get(url)
    content = json.loads(response.content)
    return content

def get_producto(id_producto):
    url = 'http://127.0.0.1:8000/api_producto/producto/'+str(id_producto)
    response = requests.get(url)
    content = json.loads(response.content)
    return content

def get_venta(id_venta):
    url = 'http://127.0.0.1:8000/api_venta/venta/'+str(id_venta)
    response = requests.get(url)
    content = json.loads(response.content)
    return content

def llenado_venta(id_venta):
    venta=get_venta(id_venta)
    subasta=get_subasta(id_venta)
    postulacion=get_postulacion(id_venta)
    producto=get_producto(str(postulacion['id_producto']))
    if venta['tipo_venta']=='1':
        monto_transporte = subasta['monto_subasta']
        cantidad_venta = producto['cantidad_producto']
        comision_venta = 1.25
        pago_servicio = int(monto_transporte)+int(producto['precio_producto'])*comision_venta
        monto_bruto_venta = pago_servicio*1.25
        monto_aduanas=monto_bruto_venta*.25
        iva = .19
        monto_neto_venta=monto_bruto_venta*1.19
        js = ({'monto_bruto_venta':monto_bruto_venta.__round__(),'iva':iva,'monto_neto_venta':monto_neto_venta.__round__(),'cantidad_venta':cantidad_venta,'monto_transporte':monto_transporte,'monto_aduanas':monto_aduanas,'pago_servicio':pago_servicio.__round__(),'comision_venta':comision_venta})
        return js
    else:
        monto_transporte = subasta['monto_subasta']
        cantidad_venta = producto['cantidad_producto']
        comision_venta = 1.25
        pago_servicio = int(monto_transporte)+int(producto['precio_producto'])*comision_venta
        monto_aduanas=0
        iva=0.19
        monto_neto_venta=pago_servicio*1.19
        js = ({'monto_bruto_venta':pago_servicio.__round__(),'iva':iva,'monto_neto_venta':monto_neto_venta.__round__(),'cantidad_venta':cantidad_venta,'monto_transporte':monto_transporte,'monto_aduanas':monto_aduanas,'pago_servicio':pago_servicio.__round__(),'comision_venta':comision_venta})
        return js

