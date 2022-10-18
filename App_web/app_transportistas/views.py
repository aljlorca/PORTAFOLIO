from django.shortcuts import render,redirect
from app.controllers import get_session


# Create your views here.
def transportista(request):
    data = get_session(request)
    if data['cargo']!='Transportista':
        return redirect(to="http://127.0.0.1:3000/")
    return render(request, 'app/transportistas.html',data)