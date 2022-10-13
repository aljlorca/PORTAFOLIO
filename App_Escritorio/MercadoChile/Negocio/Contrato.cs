using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class Contrato
    {
        public int id_contrato { get; set; }
        public List<IFormFile> documento_contrato { get; set; }
        public DateTime fecha_contrato { get; set; }
        public string tipo_contrato { get; set; }
        public int id_empresa { get; set; }
    }
}
