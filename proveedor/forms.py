from django import forms
from .models import proveedor

class AgregarProveedorForms(forms.ModelForm):
    class Meta:
        model = proveedor
        fields = '__all__'
