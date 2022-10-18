using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class getContrato
    {
        private string url = "http://127.0.0.1:8004/api/contrato/";
        private string url2 = "http://127.0.0.1:8005/api/empresa/";
        public async Task<string> GetHttp2()
        {

            WebRequest oRequest = WebRequest.Create(url2);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
