﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Postulacion
    {
        public string id_postulacion { get; set; }
        public string descripcion_postulacion { get; set; }
        public string estado_postulacion { get; set; }
        public string id_venta { get; set; }
        public string estado_fila { get; set; }
        public string id_usuario { get; set; }
        public string id_producto { get; set; }
    }
}