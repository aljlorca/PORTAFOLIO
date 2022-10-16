from django.shortcuts import render


# Create your views here.
def transportista(request):
    return render(request, 'app/transportistas.html')