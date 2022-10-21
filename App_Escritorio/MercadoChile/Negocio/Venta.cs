using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Venta
    {
        public int id_venta { get; set; }
        public string descripcion_venta { get; set; }
        public string estado_venta { get; set; }
        public int monto_bruto_venta { get; set; }
        public string iva { get; set; }
        public int monto_neto_venta { get; set; }
        public string fecha_venta { get; set; }
        public string tipo_venta { get; set; }
        public int id_usuario { get; set; }
        


    }
}
