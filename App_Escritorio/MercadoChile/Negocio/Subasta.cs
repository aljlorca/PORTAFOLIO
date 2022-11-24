using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Subasta
    {
        public string id_subasta { get; set; }
        public int monto_subasta { get; set; }
        public string id_venta { get; set; }
        public string fecha_subasta { get; set; }
        public string estado_subasta { get; set; }
        public string id_usuario { get; set; }
        public string id_carga { get; set; }
        public string capacidad_carga { get; set; }
        public string refrigeracion_carga { get; set; }
        public string tamano_carga { get; set; }
    }
}
