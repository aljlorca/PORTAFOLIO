﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoChile.Modelos
{
    public class Usuarios
    {
        public int id_usuario { get; set; }
        public string numero_identificacion_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string direccion_usuario { get; set; }
        public string telefono_usuario { get; set; }
        public string correo_usuario { get; set; }
        public string contrasena_usuario { get; set; }
        public char administrador_usuario { get; set; }
        public int id_cargo { get; set; }
        public int id_empresa { get; set; }
        public int id_pais { get; set; }
        public int id_region { get; set; }
        public int id_ciudad { get; set; }
    }
}
