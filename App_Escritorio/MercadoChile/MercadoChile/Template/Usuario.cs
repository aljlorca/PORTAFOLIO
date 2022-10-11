using Amazon.Runtime.Internal;
using MercadoChile.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using static MercadoChile.Form1;
using Cargo = MercadoChile.Modelos.Cargo;
using ComboBox = System.Windows.Forms.ComboBox;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MercadoChile
{


    public partial class Usuario : Form
    {
        DBApi DBApi = new DBApi();
        public static bool IsValidEmail(string email)
        {
            try
            {
                var endericoEmail = new System.Net.Mail.MailAddress(email);
                return endericoEmail.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();

                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }


        Uri baseUri = new Uri("http://127.0.0.1:8015/api/usuario_old/");
        private string url = "http://127.0.0.1:8015/api/usuario/";
        private string url1 = "http://127.0.0.1:8000/api/cargo/";
        private string url2 = "http://127.0.0.1:8005/api/pais/";
        private string url3 = "http://127.0.0.1:8009/api/region/";
        private string url4 = "http://127.0.0.1:8001/api/ciudad/";
        private string url5 = "http://127.0.0.1:8003/api/empresa/";


        public Usuario()
        {
            InitializeComponent();
        }


        private async void Clientes_Carga(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            string respuesta1 = await GetHttp1();
            string respuesta2 = await GetHttp2();
            string respuesta5 = await GetHttp5();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            List<Empresa> lista5 = JsonConvert.DeserializeObject<List<Empresa>>(respuesta5);
            cmbCargo.DataSource = lista1;
            cmbPais.DataSource = lista2;
            cmbEmpresa.DataSource = lista5;
            lista1.RemoveAt(0);
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.ValueMember = "id_cargo";
            cmbPais.DisplayMember = "nombre_pais";
            cmbPais.ValueMember = "id_pais";
            cmbEmpresa.DisplayMember = "razon_social_empresa";
            cmbEmpresa.ValueMember = "id_empresa";
        }
        private async void cmbPais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id_pais = Convert.ToInt32(((ComboBox)sender).SelectedValue);
            string respuesta3 = await GetHttp3();
            List<Regiones> lista3 = JsonConvert.DeserializeObject<List<Regiones>>(respuesta3);
            cmbRegion.DisplayMember = "nombre_region";
            cmbRegion.ValueMember = "id_region";
            cmbRegion.DataSource = lista3.Where(x => x.id_pais == id_pais).ToList();

        }
        private async void cmbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id_region = Convert.ToInt32(((ComboBox)sender).SelectedValue);

            string respuesta4 = await GetHttp4();
            List<Ciudad> lista3 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);
            cmbCiudad.DisplayMember = "nombre_ciudad";
            cmbCiudad.ValueMember = "id_ciudad";
            cmbCiudad.DataSource = lista3.Where(x => x.id_region == id_region).ToList();
        }



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
        public async Task<string> GetHttp5()
        {

            WebRequest oRequest = WebRequest.Create(url5);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

            foreach (var list in lista)
            {
                if (list.correo_usuario == txtCorEdit.Text)
                {

                    int id = list.id_usuario;

                    Usuarios post = new Usuarios()
                    {

                        correo_usuario = txtCorEdit.Text,

                    };
                    var data = JsonSerializer.Serialize<Usuarios>(post);
                    HttpRequestMessage request = new HttpRequestMessage
                    {

                        Content = new StringContent(data, Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(baseUri, id.ToString()),
                    };
                    var httpClient = new HttpClient();

                    if (MessageBox.Show("Desea Eliminar" + txtCorEdit, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        await httpClient.SendAsync(request);
                        this.Hide();
                    }
                    else
                    {
                        txtRutEdit.Text = "";
                        txtNomEdit.Text = "";
                        txtDirEdit.Text = "";
                        txtTeleEdit.Text = "";
                        txtCorEdit.Text = "";
                        txtConEdit.Text = "";
                        cmbPaisEdit.Text = "";
                        cmbRegionEdit.Text = "";
                        cmbCargo.Text = "";
                        cmbEmpresa.Text = "";
                        cmbCiudad.Text = "";
                    }




                }
            }
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

            foreach (var list in lista)
            {
                if (list.numero_identificacion_usuario == txtRutEdit.Text)
                {
                    if (cmbCiudadEdit.Text == "")
                    {
                        MessageBox.Show("ingrese una ciudad");
                    }
                    else
                    {
                        int id = list.id_usuario;

                        int cargo = (int)cmbCargoEdit.SelectedValue;
                        int empresa = (int)cmbEmpresaEdit.SelectedValue;
                        int ciudad = (int)cmbCiudadEdit.SelectedValue;

                        Uri myUri = new Uri(baseUri, id.ToString());
                        var client = new HttpClient();
                        Usuarios post = new Usuarios()
                        {
                            numero_identificacion_usuario = txtRutEdit.Text,
                            nombre_usuario = txtNomEdit.Text,
                            direccion_usuario = txtDirEdit.Text,
                            telefono_usuario = txtTeleEdit.Text,
                            correo_usuario = txtCorEdit.Text,
                            contrasena_usuario = txtConEdit.Text,
                            administrador_usuario = '0',
                            id_cargo = cargo,
                            id_empresa = empresa,
                            id_ciudad = ciudad,
                        };
                        var data = JsonSerializer.Serialize<Usuarios>(post);
                        HttpContent content =
                            new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                        var httpResponse = await client.PutAsync(myUri, content);


                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var result = await httpResponse.Content.ReadAsStringAsync();
                            var postResult = JsonSerializer.Deserialize<Usuarios>(result);
                            MessageBox.Show(postResult.ToString());
                            this.Hide();

                        }
                    }
                }
            }
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (cmbCiudad.Text == "")
            {
                MessageBox.Show("ingrese una ciudad");
            }
            else
            {
                int cargo = (int)cmbCargo.SelectedValue;
                int empresa = (int)cmbEmpresa.SelectedValue;
                int ciudad = (int)cmbCiudad.SelectedValue;
                var client = new HttpClient();


                Usuarios post2 = new Usuarios()
                {

                    numero_identificacion_usuario = txtRutUsua.Text,
                    nombre_usuario = txtNombreUsua.Text,
                    direccion_usuario = txtDirecUsua.Text,
                    telefono_usuario = txtTelUsua.Text,
                    correo_usuario = txtCorUsua.Text,
                    contrasena_usuario = txtConUsua.Text,
                    administrador_usuario = '0',
                    id_cargo = cargo,
                    id_empresa = empresa,
                    id_ciudad = ciudad



                };
                var data = JsonSerializer.Serialize<Usuarios>(post2);
                HttpContent content =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var valido = validarRut(txtRutUsua.Text);
                if (IsValidEmail(txtCorUsua.Text))
                {
                    if (cmbCiudad.Text == "Chile")
                    {
                        if (valido == true)
                        {
                            var httpResponse = await client.PostAsync(baseUri, content);
                            if (httpResponse.IsSuccessStatusCode)

                            {

                                var result = await httpResponse.Content.ReadAsStringAsync();
                                var postResult = JsonSerializer.Deserialize<Usuarios>(result);
                                this.Hide();

                            }
                        }
                        else

                        {
                            MessageBox.Show("rut malo");
                        }
                    }
                    else
                    {
                        var httpResponse = await client.PostAsync(baseUri, content);
                        if (httpResponse.IsSuccessStatusCode)

                        {

                            var result = await httpResponse.Content.ReadAsStringAsync();
                            var postResult = JsonSerializer.Deserialize<Usuarios>(result);
                            this.Hide();

                        }
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dynamic response = DBApi.Get("http://127.0.0.1:8015/api/usuario/");
            DgvClientes.DataSource = response;
            string respuesta1 = await GetHttp1();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            string respuesta2 = await GetHttp4();
            List<Ciudad> lista2 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta2);
            string respuesta3 = await GetHttp5();
            List<Empresa> lista3 = JsonConvert.DeserializeObject<List<Empresa>>(respuesta3);
            this.DgvClientes.Columns[0].Visible = false;
            foreach (DataGridViewRow fila in DgvClientes.Rows)
            {
                foreach (var fila1 in lista1)
                {
                    if (Convert.ToInt32(fila.Cells["cnCargo"].Value) == fila1.id_cargo)
                    {
                        fila.Cells["cnCargo"].Value = fila1.nombre_cargo;
                        break;
                    }
                }
                foreach (var fila2 in lista2)
                {
                    if (Convert.ToInt32(fila.Cells["cnCiudad"].Value) == fila2.id_ciudad)
                    {
                        fila.Cells["cnCiudad"].Value = fila2.nombre_ciudad;
                        break;
                    }

                }
                foreach (var fila3 in lista3)
                {
                    if (Convert.ToInt32(fila.Cells["cnEmpresa"].Value) == fila3.id_empresa)
                    {
                        fila.Cells["cnEmpresa"].Value = fila3.razon_social_empresa;

                        break;
                    }
                }
            }
            foreach (DataGridViewRow fila in DgvClientes.Rows)
            {
                if (fila.Cells["cnCargo"].Value.ToString() == "Administrador")
                {
                    fila.Visible = false;
                    break;
                }
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            txtRutEdit.Text = DgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtNomEdit.Text = DgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtDirEdit.Text = DgvClientes.CurrentRow.Cells[3].Value.ToString();
            txtTeleEdit.Text = DgvClientes.CurrentRow.Cells[4].Value.ToString();
            txtCorEdit.Text = DgvClientes.CurrentRow.Cells[5].Value.ToString();
            string respuesta4 = await GetHttp4();
            string respuesta1 = await GetHttp1();
            string respuesta5 = await GetHttp5();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            List<Ciudad> lista3 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);
            List<Empresa> lista5 = JsonConvert.DeserializeObject<List<Empresa>>(respuesta5);
            lista1.RemoveAt(0);
            cmbCargoEdit.DataSource = lista1;
            cmbCiudadEdit.DataSource = lista3;
            cmbEmpresaEdit.DataSource = lista5;
            cmbCargoEdit.DisplayMember = "nombre_cargo";
            cmbCargoEdit.ValueMember = "id_cargo";
            cmbEmpresaEdit.DisplayMember = "razon_social_empresa";
            cmbEmpresaEdit.ValueMember = "id_empresa";
            cmbCiudadEdit.DisplayMember = "nombre_ciudad";
            cmbCiudadEdit.ValueMember = "id_ciudad";
            cmbCargoEdit.Text = DgvClientes.CurrentRow.Cells[6].Value.ToString();
            cmbEmpresaEdit.Text = DgvClientes.CurrentRow.Cells[7].Value.ToString();
            cmbCiudadEdit.Text = DgvClientes.CurrentRow.Cells[8].Value.ToString();
            string respuesta2 = await GetHttp2();
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            cmbPaisEdit.DataSource = lista2;
            cmbPaisEdit.DisplayMember = "nombre_pais";
            cmbPaisEdit.ValueMember = "id_pais";
        }
    }
}
