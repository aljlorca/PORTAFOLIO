using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Negocio;
using System.Linq;
using System.Security.Policy;
using static System.Net.WebRequestMethods;

namespace MercadoChile.Template
{

    public partial class Publiacion : Form
    {
        private string url = "http://127.0.0.1:8010/api/producto/";
        DBApi DBApi = new DBApi();
        public Publiacion()
        {
            InitializeComponent();
        }
        public async Task<string> GetHttp()
        {

            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        
        private async void btnListar_Click(object sender, EventArgs e)
        { 
            string respuesta = await GetHttp();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            dgvProducto.DataSource = lista;
            foreach (DataGridViewRow fila in dgvProducto.Rows)
            {
                
                foreach (var fila1 in lista)
                {
                    if (fila.Cells["cnImagen"].Value.ToString() == fila1.imagen_producto)
                    {
                        
                        string urls = fila.Cells["cnImagen"].Value.ToString();
                        Console.WriteLine(urls);
                        
                        break;
                    }

                }
                
            }
        }

        
    
    }
    
}
