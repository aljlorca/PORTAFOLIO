using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Pedido
    {
        public int id_pedido { get; set; }
        public string descripcion_pedido { get; set; }
        public string fecha_sla_pedido { get; set; }
        public int id_usuario { get; set; }
    }
}
