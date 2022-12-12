import requests
import pandas as pd
import json

def import_data(id_venta):
    url = 'http://127.0.0.1:8000/api_producto/producto_venta/'+str(id_venta)
    response = requests.get(url)
    content = json.loads(response.content)
    return content

def aceptar_postulacion(id_postulacion):
    url = 'http://127.0.0.1:8000/api_postulacion/postulacion_old/'+str(id_postulacion)
    response = requests.put(url)
    content = json.loads(response.content)
    return content 

def rechazar_postulacion(id_postulacion):
    url = 'http://127.0.0.1:8000/api_postulacion/postulacion_rechazar/'+str(id_postulacion)
    response = requests.put(url)
    content = json.loads(response.content)
    return content

def saldo_producto(id_producto):
    url = 'http://127.0.0.1:8000/api_producto/producto_old/'+str(id_producto)
    response = requests.put(url)
    content = json.loads(response.content)
    return content

def get_mejor_producto(id_venta):
    pd.options.mode.chained_assignment = None
    data = import_data(id_venta)

    df = pd.DataFrame(data)


    df_best = df[df.descripcion_calidad == 'A']


    df_best['cantidad_producto'] = df_best['cantidad_producto'].astype('string')
    df_best['cantidad_producto'] = df_best['cantidad_producto'].str.replace(',', '.')
    df_best['cantidad_producto'] = df_best['cantidad_producto'].astype('float')
    df_best_cantidades = df_best[df_best.cantidad_producto >= df_best['cantidad_producto'].mean()]
    df_best_precio = df_best_cantidades[df_best_cantidades.precio_producto == df_best_cantidades['precio_producto'].min()]
    df_best_precio['cantidad_producto'] = df_best_precio['cantidad_producto'].astype('string')
    df_best_precio['cantidad_producto'] = df_best_precio['cantidad_producto'].str.replace('.', ',')
    resultado=df_best_precio.to_json(orient="records")
    producto = json.loads(resultado)
    producto=producto[0]
    df = df[df["id_producto"].str.contains(producto['id_producto']) == False]
    resultado_restantes=df.to_json(orient="records")
    restantes = json.loads(resultado_restantes)
    res=aceptar_postulacion(producto['id_postulacion'])
    respt_postulacion=[]
    respt_productos=[]
    cont = 0
    for i in restantes:
        fila=restantes[cont]
        res=rechazar_postulacion(fila['id_postulacion'])
        res_pr=saldo_producto(fila['id_producto'])
        respt_postulacion.append(res)
        respt_productos.append(res_pr)

        cont = cont+1

    return({"producto_aceptado":producto,"productos_rechazados":restantes, "respuestas_postulacion":respt_postulacion,"respuesta_productos":respt_productos})