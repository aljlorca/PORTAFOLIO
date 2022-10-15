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
        public string fecha_pedido { get; set; }
        public string id_venta { get; set; }
        public int id_producto { get; set; }
    }
}
