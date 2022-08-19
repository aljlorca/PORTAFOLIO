from cargo.models import cargo
from django.db import models
from django.contrib.auth.base_user import AbstractBaseUser, BaseUserManager
from django.db.models.query import prefetch_related_objects
# Create your models here.
class UsuarioManager(BaseUserManager):
    def create_user(self,username,correo,nombre_completo,rut,telefono, direccion,password=None):
        if not correo:
            raise ValueError('El usuario debe tener un correo electronico')
        usuario = self.model(
            username = username,
            correo=self.normalize_email(correo),
            nombre_completo = nombre_completo, 
            rut=rut,
            telefono = telefono

        )
        usuario.set_password(password)
        usuario.save()
        return usuario

    def create_superuser(self,username,rut,correo,nombre_completo,telefono,direccion,password):
        usuario = self.create_user(
            correo=correo,
            username = username,
            rut=rut,
            nombre_completo = nombre_completo, 
            telefono = telefono,
            password=password,
            direccion=direccion
        
        )
        usuario.usuario_administrador = True
        usuario.save()
        return usuario


class Usuario(AbstractBaseUser):
    username = models.CharField('Nombre de usuario',unique=True,max_length=100)
    correo = models.CharField('Correo',unique=True,max_length=300)   
    nombre_completo = models.CharField('Nombre Completo',max_length=150)
    rut = models.IntegerField('Run', unique=True)
    telefono = models.IntegerField('Telefono', unique=True)
    direccion = models.CharField('Dirección', max_length=300,default='',null=True)
    usuario_activo = models.BooleanField(default=True)
    usuario_administrador = models.BooleanField(default=False)
    cargo = models.ForeignKey(cargo, on_delete=models.CASCADE,null=True)
    objects = UsuarioManager()

    USERNAME_FIELD = 'username'
    REQUIRED_FIELDS = ['correo','nombre_completo','rut','telefono','direccion']
    def __str__(self):
        return f'{self.nombre_completo}'
    
    def has_perm(self,perm,obj = None):
        return True
    
    def has_module_perms(self,app_label):
        return True
    
    @property
    def is_staff(self):
        return self.usuario_administrador
