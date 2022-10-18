using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Subasta
    {
        public int id_subasta { get; set; }
        public int monto_subasta { get; set; }
        public string id_venta { get; set; }
        public string fecha_subasta { get; set; }
        public string id_usuario { get; set; }
    }
}
