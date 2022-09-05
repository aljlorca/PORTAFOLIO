using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoChile
{
    public partial class Clientes : Form
    {
        private string url = "http://127.0.0.1:8002/api/cargo/?format=json";
        public Clientes()
        {
            InitializeComponent();
        }
        DBApi dBApi = new DBApi();

        private async void Clientes_Load(object sender, EventArgs e)
        {
            string respuesta1 = await GetHttp();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            cmbCargo.DataSource = lista1;
            cmbCargo.DisplayMember = "id";
            cmbCargo.ValueMember = "id";

            int indice = cmbCargo.SelectedIndex;
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string json = "{\"rut_cliente_interno\": \"" + txtRutCliente.Text + "\",\"nombre_cliente_interno\":\""+ txtNombreCliente.Text + "\",\"direccion_cliente_interno\":\"" + txtDireccion.Text + "\",\"telefono_cliente_interno\":\"" + txtTelefono.Text + "\",\"correo_cliente_interno\":\"" + txtCorreo.Text + "\",\"contrasena_cliente_interno\":\"" + txtContraseña.Text + "\",\"cargo_id_cargo\":\"" + cmbCargo.SelectedIndex.ToString() + "\"}";
            
            dynamic respuesta = dBApi.Post("http://127.0.0.1:8000/api/Cliente_Interno/?format=json", json);

            MessageBox.Show(respuesta.ToString());
        }

        public class Cargo
        {
            public int id { get; set; }
            public string nombre_cargo { get; set; }
            public string descripcion { get; set; }
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbCargo.SelectedIndex;

            lblPrueba.Text = cmbCargo.Items[indice].ToString();


        }
    }
}
