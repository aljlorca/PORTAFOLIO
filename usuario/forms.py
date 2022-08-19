from django import forms
from django.contrib.auth.forms import AuthenticationForm
from django.db.models import fields
from django.forms import widgets
from django.forms.forms import Form
from usuario.models import Usuario



class FormularioUsuario(forms.ModelForm):
    password1 = forms.CharField(label= 'Contraseña',widget=forms.PasswordInput(
        attrs= {
            'class':'form-control',
            'placeholder':'Ingrese una contraseña',
            'id':'password1',
            'required':'required',
        }

    ))
    password2 = forms.CharField(label= 'Contraseña',widget=forms.PasswordInput(
        attrs= {
            'class':'form-control',
            'placeholder':'Ingrese nuevamente su contraseña',
            'id':'password2',
            'required':'required',
        }

    ))
    class Meta:
        model = Usuario
        fields = ('username','correo','nombre_completo','rut','telefono','direccion')
        widgets = {
            'correo': forms.EmailInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Correo electronico'
                }
            ),
            'nombre_completo':forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su nombre completo'
                }
            ),
            'username': forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su nombre de usuario'
                }
            ),
            'rut': forms.NumberInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su rut sin puntos ni guión'
                }
            ),
            'telefono': forms.NumberInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su telefono de 9 digitos'
                }
            ),
            'direccion': forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su dirección'
                }
            )
        }
    def clean_password2(self):
        password1 = self.cleaned_data.get('password1')
        password2 = self.cleaned_data.get('password2')
        if password1 != password2:
            raise forms.ValidationError('Las contraseñas no coinciden')
        return password2
    
    def save(self,commit = True):
        user = super().save(commit=False)
        user.set_password(self.cleaned_data['password1'])
        if commit:
            user.save()
        return user





class FormularioUsuarioCompleto(forms.ModelForm):

    class Meta:
        model = Usuario
        fields = ('username','correo','nombre_completo','rut','telefono','direccion','usuario_activo','usuario_administrador','cargo')
        widgets = {
            'correo': forms.EmailInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Correo electronico'
                }
            ),
            'nombre_completo':forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su nombre completo'
                }
            ),
            'username': forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su nombre de usuario'
                }
            ),
            'rut': forms.NumberInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su rut sin puntos ni guión'
                }
            ),
            'telefono': forms.NumberInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su telefono de 9 digitos'
                }
            ),
            'direccion': forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su dirección'
                }
            )
        }


class AgregadoAdminForms(forms.ModelForm):
    password1 = forms.CharField(label= 'Contraseña',widget=forms.PasswordInput(
        attrs= {
            'class':'form-control',
            'placeholder':'Ingrese una contraseña',
            'id':'password1',
            'required':'required',
        }

    ))
    password2 = forms.CharField(label= 'Contraseña',widget=forms.PasswordInput(
        attrs= {
            'class':'form-control',
            'placeholder':'Ingrese nuevamente su contraseña',
            'id':'password2',
            'required':'required',
        }

    ))
    class Meta:
        model = Usuario
        fields = ('username','correo','nombre_completo','rut','telefono','direccion','usuario_activo','usuario_administrador','cargo')
        widgets = {
            'correo': forms.EmailInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Correo electronico'
                }
            ),
            'nombre_completo':forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su nombre completo'
                }
            ),
            'username': forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su nombre de usuario'
                }
            ),
            'rut': forms.NumberInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su rut sin puntos ni guión'
                }
            ),
            'telefono': forms.NumberInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su telefono de 9 digitos'
                }
            ),
            'direccion': forms.TextInput(
                attrs= {
                    'class':'form-control',
                    'placeholder':'Ingrese su dirección'
                }
            )
        }
    def clean_password2(self):
        password1 = self.cleaned_data.get('password1')
        password2 = self.cleaned_data.get('password2')
        if password1 != password2:
            raise forms.ValidationError('Las contraseñas no coinciden')
        return password2
    
    def save(self,commit = True):
        user = super().save(commit=False)
        user.set_password(self.cleaned_data['password1'])
        if commit:
            user.save()
        return user