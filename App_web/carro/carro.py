class Carro:
    def __init__(self, request):
        self.request = request
        self.session=request.session
        carro=self.session.get("carro")
        if not carro:
            carro=self.session["carro"]={}
        #else:
        self.carro=carro

    def agregar(self, Producto):
        if(str(Producto['id_producto']) not in self.carro.keys()):
            self.carro[Producto['id_producto']]={
                "id_producto":Producto['id_producto'],
                "nombre_producto":Producto['nombre_producto'],
                "precio_producto":str(Producto['precio_producto']),
                "cantidad":str(Producto['cantidad_producto']),
            }
        else:
            for key, value in self.carro.items():
                if key==str(Producto['id_producto']):
                    value["cantidad"]=value["cantidad"]+1
                    value["precio_producto"]=int(value["precio_producto"])+Producto['precio_producto']
                    break
        self.guardar_carro()

    def agregar_home(self, Producto):
        if(str(Producto['id_producto']) not in self.carro.keys()):
            self.carro[Producto['id_producto']]={
                "id_producto":Producto['id_producto'],
                "nombre_producto":Producto['nombre_producto'],
                "precio_producto":str(Producto['precio_producto']),
                "cantidad":str(Producto['cantidad_producto']),
            }
        else:
            for key, value in self.carro.items():
                if key==str(Producto['id_producto']):
                    value["cantidad"]=value["cantidad"]+1
                    value["precio_producto"]=int(value["precio_producto"])+Producto['precio_producto']
                    break
        self.guardar_carro()

    def guardar_carro(self):
        self.session["carro"]=self.carro
        self.session.modified=True

    def eliminar(self, Producto):
        if str(Producto['id_producto']) in self.carro:
            del self.carro[Producto['id_producto']]
            self.guardar_carro()
    
    def restar_producto(self, Producto):
        for key, value in self.carro.items():
                if key==str(Producto['id_producto']):
                    value["cantidad"]=value["cantidad"]-1
                    value["precio_producto"]=int(value["precio_producto"])-Producto['precio_producto']
                    if value["cantidad"]<1:
                        self.eliminar(Producto)
                    break
        self.guardar_carro()
        
    def limpiar_carro(self):
        self.session["carro"]={}
        self.session.modified=True