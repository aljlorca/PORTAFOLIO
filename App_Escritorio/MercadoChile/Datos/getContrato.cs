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
        private string url = "http://127.0.0.1:8000/api_empresa/empresa/";
        private string url1 = "http://127.0.0.1:8000/api_usuario/usuario/";
        private string url2 = "http://127.0.0.1:8000/api_cargo/cargo/";
        public async Task<string> GetHttp()
        {

            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public async Task<string> GetHttp1()
        {

            WebRequest oRequest = WebRequest.Create(url1);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttp2()
        {

            WebRequest oRequest = WebRequest.Create(url2);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
