using MercadoChile.Modelos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MercadoChile.Template
{
    public partial class editarClientes : Form
    {

        Form1 form1;
        Uri baseUri = new Uri("http://127.0.0.1:8000/api/cliente_interno/");
        private string url = "http://127.0.0.1:8000/api/cliente_interno/";
        private string url1 = "http://127.0.0.1:8002/api/cargo/?format=json";
        public editarClientes()
        {
            InitializeComponent();
        }
        private async void Clientes_Load(object sender, EventArgs e)
        {
            string respuesta1 = await GetHttp1();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            cmbCargo.DataSource = lista1;
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.ValueMember = "id";

            
        }
        private async void Clientes_Carga(object sender, EventArgs e)
        {
            string respuesta1 = await GetHttp();
            List<clientesInternos> lista1 = JsonConvert.DeserializeObject<List<clientesInternos>>(respuesta1);
            cmbRut.DataSource = lista1;
            cmbRut.DisplayMember = "rut_cliente_interno";
            cmbRut.ValueMember = "rut_cliente_interno";

        }
        private async Task<string> GetHttp1()
        {
            WebRequest oRequest = WebRequest.Create(url1);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttp()
        {

            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string rut = cmbRut.Text;
            Uri myUri = new Uri(baseUri, rut);
            var client = new HttpClient();
            clientesInternos post = new clientesInternos()
            {
                rut_cliente_interno = int.Parse(rut),
                nombre_cliente_interno = txtNombreCliente.Text,
                direccion_cliente_interno = txtDireccion.Text,
                telefono_cliente_interno = int.Parse(txtTelefono.Text),
                correo_cliente_interno = txtCorreo.Text,
                contrasena_cliente_interno = txtContraseña.Text,
                cargo_id_cargo = int.Parse(cmbCargo.SelectedValue.ToString()),

            };
            var data = JsonSerializer.Serialize<clientesInternos>(post);
            HttpContent content =
                new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PutAsync(myUri,content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                var postResult = JsonSerializer.Deserialize<clientesInternos>(result);
                MessageBox.Show(result.ToString());
                form1 = new Form1();
                form1.Show();
                this.Hide();
            }


        }


    }
}
