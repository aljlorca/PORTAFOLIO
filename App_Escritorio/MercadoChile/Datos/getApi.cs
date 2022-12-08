using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class getApi
    {
        private string urlEmpresa = "http://127.0.0.1:8000/api_empresa/empresa/";
        private string urlUsuario = "http://127.0.0.1:8000/api_usuario/usuario/";
        private string urlCargo = "http://127.0.0.1:8000/api_cargo/cargo/";
        private string urlTipoEmpresa = "http://127.0.0.1:8000/api_tipo_empresa/tipo_empresa/";
        private string urlSubasta = "http://127.0.0.1:8000/api_subasta/subasta_aceptar/";
        private string urlVenta = "http://127.0.0.1:8000/api_venta/venta/";
        private string urlCarga = "http://127.0.0.1:8000/api_carga/carga/";
        private string urlProducto = "http://127.0.0.1:8000/api_producto/producto/";
        private string urlCalidad = "http://127.0.0.1:8000/api_calidad/calidad/";
        private string urlPostulacion = "http://127.0.0.1:8000/api_postulacion/postulacion_historico/";
        private string urlPedido = "http://127.0.0.1:8000/api_pedido/pedido/?format=json";
        public async Task<string> GetHttpEmpresa()
        {

            WebRequest oRequest = WebRequest.Create(urlEmpresa);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public async Task<string> GetHttpUsuario()
        {

            WebRequest oRequest = WebRequest.Create(urlUsuario);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttpCargo()
        {

            WebRequest oRequest = WebRequest.Create(urlCargo);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttpTipoEmpresa()
        {

            WebRequest oRequest = WebRequest.Create(urlTipoEmpresa);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public async Task<string> GetHttpSubasta()
        {

            WebRequest oRequest = WebRequest.Create(urlSubasta);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttpVenta()
        {

            WebRequest oRequest = WebRequest.Create(urlVenta);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttpCarga()
        {

            WebRequest oRequest = WebRequest.Create(urlCarga);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public async Task<string> GetHttpProducto()
        {

            WebRequest oRequest = WebRequest.Create(urlProducto);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttpCalidad()
        {

            WebRequest oRequest = WebRequest.Create(urlCalidad);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttpPostulacion()
        {

            WebRequest oRequest = WebRequest.Create(urlPostulacion);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public async Task<string> GetHttpPedido()
        {

            WebRequest oRequest = WebRequest.Create(urlPedido);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
