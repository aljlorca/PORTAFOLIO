from typing import ClassVar
from django import forms
from django.contrib import auth
from django.db import models
from django.db.models import fields
from django.forms import widgets    
from .models import *
from django.contrib.auth.models import User
from django.forms.widgets import Select


class ContactoForms(forms.ModelForm):
    
    class Meta:
        model = contacto
        #Fiedls detalla todos los datos para el formulario como se necesitan todos se usa __all__
        fields = '__all__'

#widget para fecha de vencimiento de producto


class AgregarProductoForms(forms.ModelForm):
    class Meta:
        model = producto
        fields = '__all__'
        widgets = {
        "vencimiento": forms.SelectDateWidget() 
        }

class AgregarFamiliaForms(forms.ModelForm):
    class Meta:
        model = familia
        fields = '__all__'








class AgregarOrdenForms(forms.ModelForm):
    
    class Meta:
        model = ordencompra
        fields = '__all__'
class ModificarOrdenForms(forms.ModelForm):

    class Meta:
        model = ordencompra
        fields = ('proveedor','documento','estado')
        widgets = {
            'proveedor':Select(attrs={
                'class':'form-control select2',
                'style':'width: 100%',
                'type':'disabled'

            }),
            'documento':Select(attrs={
                'class':'form-control select2',
                'style':'width: 100%',
                'type':'disabled'
            }),
            'estado': Select(attrs={
                'class':'form-control select2',
                'style':'width: 100%',
            })
        }