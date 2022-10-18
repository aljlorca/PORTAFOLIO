using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Carga
    {
        public string capacidad_carga { get; set; }
        public string refrigeracion_carga { get; set; }
        public string tamano_carga { get; set; }
        public int id_subasta { get; set; }
        public int id_usuario { get; set; }
    }
}
