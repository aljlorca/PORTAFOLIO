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
        if(str(Producto.id) not in self.carro.keys()):
            self.carro[Producto.id]={
                "producto_id":Producto.id,
                "nombre":Producto.nombre,
                "precio":str(Producto.precio),
                "cantidad":1,
                "imagen":Producto.imagen.url
            }
        else:
            for key, value in self.carro.items():
                if key==str(Producto.id):
                    value["cantidad"]=value["cantidad"]+1
                    value["precio"]=int(value["precio"])+Producto.precio
                    break
        self.guardar_carro()

    def agregar_home(self, Producto):
        if(str(Producto.id) not in self.carro.keys()):
            self.carro[Producto.id]={
                "producto_id":Producto.id,
                "nombre":Producto.nombre,
                "precio":str(Producto.precio),
                "cantidad":1,
                "imagen":Producto.imagen.url
            }
        else:
            for key, value in self.carro.items():
                if key==str(Producto.id):
                    value["cantidad"]=value["cantidad"]+1
                    value["precio"]=int(value["precio"])+Producto.precio
                    break
        self.guardar_carro()

    def guardar_carro(self):
        self.session["carro"]=self.carro
        self.session.modified=True

    def eliminar(self, Producto):
        Producto.id=str(Producto.id)
        if Producto.id in self.carro:
            del self.carro[Producto.id]
            self.guardar_carro()
    
    def restar_producto(self, Producto):
        for key, value in self.carro.items():
                if key==str(Producto.id):
                    value["cantidad"]=value["cantidad"]-1
                    value["precio"]=int(value["precio"])-Producto.precio
                    if value["cantidad"]<1:
                        self.eliminar(Producto)
                    break
        self.guardar_carro()
        
    def limpiar_carro(self):
        self.session["carro"]={}
        self.session.modified=True