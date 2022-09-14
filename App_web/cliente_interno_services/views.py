from django.shortcuts import render
from .services import *
from django.views.decorators.csrf import csrf_exempt
# Create your views here.


@csrf_exempt
def get_cliente_interno(request):
    data = {
    }

    return render(request, 'cliente_interno_services/login.html', data)



    '''
    if request.method == 'GET':
        rut_cliente_interno = request.GET.get('rut_cliente_interno')
        contrasena_cliente_interno = request.GET.get('contrasena_cliente_externo')
        salida = get_cliente_interno_rut(rut_cliente_interno)
        print(salida,rut_cliente_interno,contrasena_cliente_interno)
        #messages,success(request, "categoria agregada correctamente")'''   