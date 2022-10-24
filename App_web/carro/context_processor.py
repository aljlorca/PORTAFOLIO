
def importe_total_carro(request):
    total=0
    if 'carro' in request.session:
        for key, value in request.session["carro"].items():
            total=total+(int(value["precio_producto"]))
    return {"importe_total_carro":total}

def importe_cant_carro(request):
    total=0
    if 'carro' in request.session:
        for key, value in request.session["carro"].items():
            total=total+(value["contador"])
    return {"importe_cant_carro":total}