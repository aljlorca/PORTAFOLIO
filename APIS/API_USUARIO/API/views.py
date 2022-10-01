from django.db import connection
from django.http.response import JsonResponse
from django.views import View
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt
from .models import Usuario
from .serializers import 
from rest_framework import viewsets
import json
import cx_Oracle

# Create your views here.


