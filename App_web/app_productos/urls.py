from django.urls import URLPattern, path
from matplotlib.path import Path
from .views import productos

urlpatterns = [
    path('', productos , name="productos"),
    
]