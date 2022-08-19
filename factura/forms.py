from datetime import datetime
from factura.models import factura
from typing import ClassVar
from django import forms
from django.contrib import auth
from django.db import models
from django.db.models import fields
from django.forms import widgets
from django.forms.widgets import DateInput, NumberInput, Select

class FacturaForm(forms.ModelForm):

    class Meta:
        model = factura
        fields = '__all__'
        widgets = {
            'usuario':Select(attrs={
                'class':'form-control select2',
                'style':'width: 100%'

            }),
            'fecha': DateInput(format='%Y-%m-%d',
                attrs={
                    'value':datetime.now().strftime('%Y-%m-%d'),
                }
            ),
            'iva': NumberInput(attrs={
                'type':'hidden'
            })
        }