document.getElementById('email').addEventListener('input', function() {
    campo = event.target;
    valido = document.getElementById('emailOK');
        
    emailRegex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    //Se muestra un texto a modo de ejemplo, luego va a ser un icono
    if (emailRegex.test(campo.value)) {
      valido.innerText = "válido";
    } else {
      valido.innerText = "Favor ingresar correctamente Email";
    }
});

//Login Validacion
var btn = document.getElementById('entrar');
var clave = document.getElementById('contraseña');
var usuario = document.getElementById('email');



btn.addEventListener('click', function(evt){

      if(clave.value === ''){
        alert('el campo contraseña es obligatorio');
       

      }else if(usuario.value === ''){
        alert('el campo de usuario es obligatorio');
      

      }else if(usuario.value.length > 30){
        alert('El nombre del usuario es demasiado largo');
     

      }

//acceso usuarios


});