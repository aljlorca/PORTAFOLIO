import json
from .models import Administrador,ClienteExterno,ClienteInterno,Transportista,Proveedor
from .serializers import AdministradorSerializer,ClienteExternoSerializer,ClienteInternoSerializer,ProveedorSerializer,TransportistaSerializer
from rest_framework import viewsets

from django.views.decorators.csrf import csrf_exempt
# Create your views here.




    
class AdministradorViewset(viewsets.ModelViewSet):
    queryset = Administrador.objects.all()
    serializer_class = AdministradorSerializer

class ClienteExternoViewset(viewsets.ModelViewSet):
    queryset = ClienteExterno.objects.all()
    serializer_class = ClienteExternoSerializer

class ClienteInternoViewset(viewsets.ModelViewSet):
    queryset = ClienteInterno.objects.all()
    serializer_class = ClienteInternoSerializer

class ProveedorViewset(viewsets.ModelViewSet):
    queryset = Proveedor.objects.all()
    serializer_class = ProveedorSerializer

class TransportistaViewset(viewsets.ModelViewSet):
    queryset = Transportista.objects.all()
    serializer_class = TransportistaSerializer

