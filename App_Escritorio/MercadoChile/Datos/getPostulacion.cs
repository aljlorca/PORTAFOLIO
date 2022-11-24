using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class getPostulacion
    {
        private string url = "http://127.0.0.1:8000/api_subasta/subasta_aceptar/";
        private string url2 = "http://127.0.0.1:8000/api_usuario/usuario/";
        private string url3 = "http://127.0.0.1:8000/api_venta/venta/";
        private string url4 = "http://127.0.0.1:8000/api_carga/carga/";
        public async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
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
        public async Task<string> GetHttp3()
        {
            WebRequest oRequest = WebRequest.Create(url3);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttp4()
        {
            WebRequest oRequest = WebRequest.Create(url4);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
