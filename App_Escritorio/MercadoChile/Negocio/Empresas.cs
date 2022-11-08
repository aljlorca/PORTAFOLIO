using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoChile.Modelos
{
    public class Empresas
    {
        public int id_empresa { get; set; }
        public string duns_empresa { get; set; }
        public string razon_social_empresa { get; set; }
        public string direccion_empresa { get; set; }
        public int id_tipo_empresa { get; set; }
    }
}
