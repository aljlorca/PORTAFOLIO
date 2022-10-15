using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public int cantidad_producto { get; set; }
        public int precio_producto { get; set; }
        public string imagen_producto { get; set; }
        public string saldo_producto { get; set; }
        public string estado_fila { get; set; }
        public int id_calidad { get; set; }
        public int id_usuario { get; set; } 
    }
}
