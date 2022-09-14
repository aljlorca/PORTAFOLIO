from django.shortcuts import render
from .services import *
from django.views.decorators.csrf import csrf_exempt

# Create your views here.


@csrf_exempt
def get_proveedor(request):
    data = {
    }

    return render(request, 'proveedor_services/login.html', data)