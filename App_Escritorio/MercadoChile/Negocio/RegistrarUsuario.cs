﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RegistrarUsuario
    {
        public string numero_identificacion_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string direccion_usuario { get; set; }
        public string telefono_usuario { get; set; }
        public string correo_usuario { get; set; }
        public string contrasena_usuario { get; set; }
        public char administrador_usuario { get; set; }
        public string id_cargo { get; set; }
        public string id_empresa { get; set; }
    }
}