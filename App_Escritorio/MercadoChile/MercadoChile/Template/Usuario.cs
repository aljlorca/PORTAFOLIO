using Datos;
using MercadoChile.Modelos;
using Negocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cargo = MercadoChile.Modelos.Cargo;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MercadoChile
{


    public partial class Usuario : Form
    {
        DBApi DBApi = new DBApi();
        getUsuario Get = new getUsuario();
        #region Validadores
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
        #endregion


        Uri baseUri = new Uri("http://127.0.0.1:8000/api_usuario/usuario_old/");
        


        public Usuario()
        {
            InitializeComponent();
        }

        #region ComboBox
        private async void Clientes_Carga(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            string respuesta1 = await Get.GetHttp1();
            string respuesta5 = await Get.GetHttp2();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
            cmbCargo.DataSource = lista1;
            cmbEmpresa.DataSource = lista5;
            lista1.RemoveAt(0);
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.ValueMember = "id_cargo";
            cmbEmpresa.DisplayMember = "razon_social_empresa";
            cmbEmpresa.ValueMember = "id_empresa";
        }
        
        #endregion

     

        #region Buttons
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
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
                        cmbDireEdit.Text = "";
                        txtTeleEdit.Text = "";
                        txtCorEdit.Text = "";
                        txtConEdit.Text = "";
                        cmbCargo.Text = "";
                        cmbEmpresa.Text = "";
                    }
                }
            }
        }
        private async void btnBuscarDire_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            string respuesta = await GetHttp1();
            var myDetails = JObject.Parse(respuesta);
            var features = myDetails["features"];
            for (int i = 0; i < 4; i++)
            {
                foreach (var a in features)
                {
                    var dir = features[i];
                    lista.Add(dir["place_name"].ToString());
                    break;
                }
            }
            cmbDireEdit.DataSource = lista;

            cmbDireEdit.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnLimpiarDire_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            cmbDireEdit.DataSource = lista;
            cmbDireEdit.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

            foreach (var list in lista)
            {
                if (list.numero_identificacion_usuario == txtRutEdit.Text)
                {
                    int id = list.id_usuario;

                    string cargo = cmbCargoEdit.SelectedValue.ToString();
                    string empresa = cmbEmpresaEdit.SelectedValue.ToString();
                    Uri myUri = new Uri(baseUri, id.ToString());
                    var client = new HttpClient();
                    Usuarios post = new Usuarios()
                    {
                        numero_identificacion_usuario = txtRutEdit.Text,
                        nombre_usuario = txtNomEdit.Text,
                        direccion_usuario = cmbDireEdit.Text,
                        telefono_usuario = txtTeleEdit.Text,
                        correo_usuario = txtCorEdit.Text,
                        contrasena_usuario = txtConEdit.Text,
                        administrador_usuario = '0',
                        id_cargo = cargo,
                        id_empresa = empresa,

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

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                string cargo = cmbCargo.SelectedValue.ToString();
                string empresa = cmbEmpresa.SelectedValue.ToString();
                var client = new HttpClient();
                RegistrarUsuario post2 = new RegistrarUsuario()
                {
                    numero_identificacion_usuario = txtRutUsua.Text,
                    nombre_usuario = txtNombreUsua.Text,
                    direccion_usuario = cmbDire.Text,
                    telefono_usuario = txtTelUsua.Text,
                    correo_usuario = txtCorUsua.Text,
                    contrasena_usuario = txtConUsua.Text,
                    administrador_usuario = '0',
                    id_cargo = cargo,
                    id_empresa = empresa,
                };
                var data = JsonSerializer.Serialize<RegistrarUsuario>(post2);
                HttpContent content =
                     new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                if (cmbDire.DropDownStyle == ComboBoxStyle.DropDownList && cmbDire.Text.Contains("Chile")==true)
                {
                    var valido = validarRut(txtRutUsua.Text);
                    if (IsValidEmail(txtCorUsua.Text) && valido == true)
                    {

                        var httpResponse = await client.PostAsync(baseUri, content);
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var result = await httpResponse.Content.ReadAsStringAsync();
                            Console.WriteLine(result);
                            var postResult = JsonSerializer.Deserialize<Usuarios>(result);
                            this.Hide();

                        }
                    }
                    else
                    {
                        MessageBox.Show("rut incorrecto o correo no valido");
                    }
                }
                else if(cmbDire.DropDownStyle == ComboBoxStyle.DropDownList && IsValidEmail(txtCorUsua.Text))
                {
                    var httpResponse = await client.PostAsync(baseUri, content);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var result = await httpResponse.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                        var postResult = JsonSerializer.Deserialize<Usuarios>(result);
                        this.Hide();

                    }
                }
                else
                {
                    MessageBox.Show("ingrese un correo correcto");
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            dynamic response = DBApi.Get("http://127.0.0.1:8000/api_usuario/usuario/?format=json");
            DgvClientes.DataSource = response;
            string respuesta1 = await Get.GetHttp1();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            string respuesta5 = await Get.GetHttp2();
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
            string respuesta = await Get.GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
            DgvClientes.DataSource = (from p in lista
                                         orderby p.id_cargo descending
                                         select p).ToList();
            this.DgvClientes.Columns[0].Visible = false;
            this.DgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;    
            foreach (DataGridViewRow fila in DgvClientes.Rows)
            {
                foreach (var fila1 in lista)
                {
                    if (Convert.ToInt32(fila.Cells["cnCargo"].Value) == 1)
                    {
                        fila.Visible = false;
                        break;
                    }
                }
                foreach (var fila1 in lista1)
                {
                    if (Convert.ToInt32(fila.Cells["cnCargo"].Value) == fila1.id_cargo)
                    {
                        fila.Cells["cnCargo"].Value = fila1.nombre_cargo;
                        break;
                    }
                }               
                foreach (var fila3 in lista5)
                {
                    if (Convert.ToInt32(fila.Cells["cnEmpresa"].Value) == fila3.id_empresa)
                    {
                        fila.Cells["cnEmpresa"].Value = fila3.razon_social_empresa;

                        break;
                    }
                }
            }
        }
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            txtRutEdit.Text = DgvClientes.CurrentRow.Cells["cnNumeIdenUsuar"].Value.ToString();
            txtNomEdit.Text = DgvClientes.CurrentRow.Cells["cnNombre"].Value.ToString();
            cmbDireEdit.Text = DgvClientes.CurrentRow.Cells["cnDireccion"].Value.ToString();
            txtTeleEdit.Text = DgvClientes.CurrentRow.Cells["cnTelefono"].Value.ToString();
            txtCorEdit.Text = DgvClientes.CurrentRow.Cells["cnCorreo"].Value.ToString();           
            string respuesta1 = await Get.GetHttp1();
            string respuesta5 = await Get.GetHttp2();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
            lista1.RemoveAt(0);
            cmbCargoEdit.DataSource = lista1;
            cmbEmpresaEdit.DataSource = lista5;
            cmbCargoEdit.DisplayMember = "nombre_cargo";
            cmbCargoEdit.ValueMember = "id_cargo";
            cmbEmpresaEdit.DisplayMember = "razon_social_empresa";
            cmbEmpresaEdit.ValueMember = "id_empresa";
            txtConEdit.Text = DgvClientes.CurrentRow.Cells["cnContraseña"].Value.ToString();
            cmbCargoEdit.Text = DgvClientes.CurrentRow.Cells["cnCargo"].Value.ToString();
            cmbEmpresaEdit.Text = DgvClientes.CurrentRow.Cells["cnEmpresa"].Value.ToString();             
        }
        public async Task<string> GetHttp()
        {
            string street = cmbDire.Text;
            Uri baseUri = new Uri("https://api.mapbox.com/geocoding/v5/mapbox.places/" + street + ".json?access_token=pk.eyJ1IjoiYWxqbG9yY2EiLCJhIjoiY2w5dGM2MzhmMWtuMDNwbzBtZjYwYmthOCJ9.B2_1lvG4ivhYRMLkBdxP6w");
            WebRequest oRequest = WebRequest.Create(baseUri);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttp1()
        {
            string street = cmbDireEdit.Text;
            Uri baseUri = new Uri("https://api.mapbox.com/geocoding/v5/mapbox.places/" + street + ".json?access_token=pk.eyJ1IjoiYWxqbG9yY2EiLCJhIjoiY2w5dGM2MzhmMWtuMDNwbzBtZjYwYmthOCJ9.B2_1lvG4ivhYRMLkBdxP6w");
            WebRequest oRequest = WebRequest.Create(baseUri);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        private async void btnBuscDir_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            string respuesta = await GetHttp();
            var myDetails = JObject.Parse(respuesta);
            var features = myDetails["features"];
            for (int i = 0; i < 4; i++)
            {
                foreach (var a in features)
                {
                    var dir = features[i];
                    lista.Add(dir["place_name"].ToString());
                    break;
                }
            }
            cmbDire.DataSource = lista;

            cmbDire.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnLimpiarDir_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            cmbDire.DataSource = lista;
            cmbDire.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void txtRutUsua_Enter(object sender, EventArgs e)
        {
            if (txtRutUsua.Text == "Rut Cliente")
            {
                txtRutUsua.Text = "";
                txtRutUsua.ForeColor = Color.Black;
            }
        }

        private void txtRutUsua_Leave(object sender, EventArgs e)
        {
            if (txtRutUsua.Text == "")
            {
                txtRutUsua.Text = "Rut Cliente";
                txtRutUsua.ForeColor = Color.DimGray;

            }
        }

        private void txtNombreUsua_Enter(object sender, EventArgs e)
        {
            if (txtNombreUsua.Text == "Nombre Cliente")
            {
                txtNombreUsua.Text = "";
                txtNombreUsua.ForeColor = Color.Black;

            }
        }

        private void txtNombreUsua_Leave(object sender, EventArgs e)
        {
            if (txtNombreUsua.Text == "")
            {
                txtNombreUsua.Text = "Nombre Cliente";
                txtNombreUsua.ForeColor = Color.DimGray;
            }
        }

        private void txtDirecUsua_Enter(object sender, EventArgs e)
        {
            if (cmbDire.Text == "Direccion")
            {
                cmbDire.Text = "";
                cmbDire.ForeColor = Color.Black;

            }
        }

        private void txtDirecUsua_Leave(object sender, EventArgs e)
        {
            if (cmbDire.Text == "")
            {
                cmbDire.Text = "Direccion";
                cmbDire.ForeColor = Color.DimGray;

            }
        }

        private void txtTelUsua_Enter(object sender, EventArgs e)
        {
            if (txtTelUsua.Text == "Telefono")
            {
                txtTelUsua.Text = "";
                txtTelUsua.ForeColor = Color.Black;

            }
        }

        private void txtTelUsua_Leave(object sender, EventArgs e)
        {
            if (txtTelUsua.Text == "")
            {
                txtTelUsua.Text = "Telefono";
                txtTelUsua.ForeColor = Color.DimGray;

            }
        }

        private void txtCorUsua_Enter(object sender, EventArgs e)
        {
            if (txtCorUsua.Text == "Correo")
            {
                txtCorUsua.Text = "";
                txtCorUsua.ForeColor = Color.Black;

            }
        }

        private void txtCorUsua_Leave(object sender, EventArgs e)
        {
            if (txtCorUsua.Text == "")
            {
                txtCorUsua.Text = "Correo";
                txtCorUsua.ForeColor = Color.DimGray;

            }
        }

        private void txtConUsua_Enter(object sender, EventArgs e)
        {
            if (txtConUsua.Text == "Contraseña")
            {
                txtConUsua.Text = "";
                txtConUsua.ForeColor = Color.Black;

            }
        }

        private void txtConUsua_Leave(object sender, EventArgs e)
        {
            if (txtConUsua.Text == "")
            {
                txtConUsua.Text = "Contraseña";
                txtConUsua.ForeColor = Color.DimGray;

            }
        }
        private void cmbCargo_Enter(object sender, EventArgs e)
        {
            cmbCargo.ForeColor = Color.Black;
        }
        private void txtRutEdit_Enter(object sender, EventArgs e)
        {
            if (txtRutEdit.Text == "Rut Cliente")
            {
                txtRutEdit.Text = "";
                txtRutEdit.ForeColor = Color.Black;

            }
        }

        private void txtRutEdit_Leave(object sender, EventArgs e)
        {
            if (txtRutEdit.Text == "")
            {
                txtRutEdit.Text = "Rut Cliente";
                txtRutEdit.ForeColor = Color.DimGray;

            }

        }

        private void txtNomEdit_Enter(object sender, EventArgs e)
        {
            if (txtNomEdit.Text == "Nombre Cliente")
            {
                txtNomEdit.Text = "";
                txtNomEdit.ForeColor = Color.Black;

            }
        }

        private void txtNomEdit_Leave(object sender, EventArgs e)
        {
            if (txtNomEdit.Text == "")
            {
                txtNomEdit.Text = "Nombre Cliente";
                txtNomEdit.ForeColor = Color.DimGray;

            }
        }
        private void txtTeleEdit_Enter(object sender, EventArgs e)
        {
            if (txtTeleEdit.Text == "Telefono")
            {
                txtTeleEdit.Text = "";
                txtTeleEdit.ForeColor = Color.Black;

            }
        }

        private void txtTeleEdit_Leave(object sender, EventArgs e)
        {
            if (txtTeleEdit.Text == "")
            {
                txtTeleEdit.Text = "Telefono";
                txtTeleEdit.ForeColor = Color.DimGray;

            }
        }

        private void txtCorEdit_Enter(object sender, EventArgs e)
        {
            if (txtCorEdit.Text == "Correo")
            {
                txtCorEdit.Text = "";
                txtCorEdit.ForeColor = Color.Black;

            }
        }

        private void txtCorEdit_Leave(object sender, EventArgs e)
        {
            if (txtCorEdit.Text == "")
            {
                txtCorEdit.Text = "Correo";
                txtCorEdit.ForeColor = Color.DimGray;

            }

        }

        private void txtConEdit_Enter(object sender, EventArgs e)
        {
            if (txtConEdit.Text == "Nueva Contraseña")
            {
                txtConEdit.Text = "";
                txtConEdit.ForeColor = Color.Black;

            }
        }

        private void txtConEdit_Leave(object sender, EventArgs e)
        {
            if (txtConEdit.Text == "")
            {
                txtConEdit.Text = "Nueva Contraseña";
                txtConEdit.ForeColor = Color.DimGray;

            }
        }

        private void cmbEmpresa_Click(object sender, EventArgs e)
        {
            cmbEmpresa.ForeColor = Color.Black;
        }
    }
}
#endregion