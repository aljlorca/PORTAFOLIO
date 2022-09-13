from django.shortcuts import render
from .services import *
from django.views.decorators.csrf import csrf_exempt
# Create your views here.


@csrf_exempt
def get_cliente_externo(request):

    if request.method == 'POST':
        rut_cliente_externo = request.POST.get('rut_cliente_externo')
        contrasena_cliente_externo = request.POST.get('contrasena_cliente_externo')
        salida = get_cliente_externo_rut(rut_cliente_externo)
        print(salida,rut_cliente_externo,contrasena_cliente_externo)
        #messages,success(request, "categoria agregada correctamente")
    return render(request, 'cliente_externo_services/login.html', data)