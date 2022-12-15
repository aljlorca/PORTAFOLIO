using MercadoChile.Modelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using static MercadoChile.Form1;
using Cargo = MercadoChile.Modelos.Cargo;
using ComboBox = System.Windows.Forms.ComboBox;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Amazon.Runtime.Internal;
using Negocio;
using Datos;
using System.Windows.Media;
using System.Drawing;
using Newtonsoft.Json.Linq;


namespace MercadoChile.Template
{
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }


        DBApi DBApi = new DBApi();
        getApi Get = new getApi();

        Uri baseUri = new Uri("http://127.0.0.1:8000/api_empresa/empresa_old/");
        

        
        private async void  Empresa_Carga(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttpTipoEmpresa();
            List<tipoEmpresa> lista = JsonConvert.DeserializeObject<List<tipoEmpresa>>(respuesta);
            lista.RemoveAt(0);
            cmbEmpresa.DataSource = lista;;
            cmbEmpresa.DisplayMember = "tipo_empresa";
            cmbEmpresa.ValueMember = "id_tipo_empresa";
        }      

        
    
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try { 
            string respuesta = await Get.GetHttpUsuario();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

                foreach (var list in lista)
                {
                    if (list.correo_usuario == txtDunsEdit.Text)
                    {

                         string id = list.id_usuario;



                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Delete,
                            RequestUri = new Uri(baseUri, id.ToString()),
                        };
                        var httpClient = new HttpClient();

                        if (MessageBox.Show("Desea Eliminar" + txtDunsEdit, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            await httpClient.SendAsync(request);
                            MessageBox.Show("Empresa Eliminada con exito");
                            this.Hide();
                        }
                        else
                        {
                            txtDunsEdit.Text = "";
                            txtRazonEdit.Text = "";
                            cmbDireEdit.Text = "";
                            cmbTipoEmpEdit.Text = "";
                            cmbEmpresa.Text = "";
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
            
            string respuesta = await Get.GetHttpUsuario();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

                foreach (var list in lista)
                {
                    if (list.numero_identificacion_usuario == txtDunsEdit.Text)
                    {


                        string id = list.id_usuario;

                        int empresa = (int)cmbTipoEmpEdit.SelectedValue;
                        Uri myUri = new Uri(baseUri, id.ToString());
                        var client = new HttpClient();
                        Empresas post = new Empresas()
                        {
                            duns_empresa = txtDunsEdit.Text,
                            razon_social_empresa = txtRazonEdit.Text,
                            direccion_empresa = cmbDireEdit.Text,
                            id_tipo_empresa = empresa,

                        };
                        var data = JsonSerializer.Serialize<Empresas>(post);
                        HttpContent content =
                            new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                        if (cmbDireEdit.DropDownStyle == ComboBoxStyle.DropDownList)
                        {
                            var httpResponse = await client.PutAsync(myUri, content);
                            if (httpResponse.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Empresa Modificada");
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("ingrese una direccion");
                        }
                    } 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    int empresa = (int)cmbEmpresa.SelectedValue;
                    var client = new HttpClient();
                    Empresas post2 = new Empresas()
                    {

                        duns_empresa = txtDunsEmp.Text,
                        razon_social_empresa = txtRazonSocial.Text,
                        direccion_empresa = cmbDire.Text,
                        id_tipo_empresa = empresa,


                    };


                    var data = JsonSerializer.Serialize<Empresas>(post2);
                    HttpContent content =
                        new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    if (cmbDire.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        var httpResponse = await client.PostAsync(baseUri, content);
                        if (httpResponse.IsSuccessStatusCode)

                        {
                            MessageBox.Show("Empresa Agregada con exito");
                            this.Hide();

                        }
                    }
                    else
                    {
                        MessageBox.Show("ingrese una direccion");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic response = DBApi.Get("http://127.0.0.1:8000/api_empresa/empresa/?format=json");
                DgvEmpresa.DataSource = response;
                string respuesta5 = await Get.GetHttpTipoEmpresa();
                List<tipoEmpresa> lista5 = JsonConvert.DeserializeObject<List<tipoEmpresa>>(respuesta5);
                this.DgvEmpresa.Columns[0].Visible = false;
                this.DgvEmpresa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewRow fila in DgvEmpresa.Rows)
                {
                    foreach (var fila3 in lista5)
                    {
                        if (Convert.ToInt32(fila.Cells["cnTipoEmpresa"].Value) == fila3.id_tipo_empresa)
                        {
                            fila.Cells["cnTipoEmpresa"].Value = fila3.tipo_empresa;
                            break;
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try {
                txtDunsEdit.Text = DgvEmpresa.CurrentRow.Cells["cnDunsEmpresa"].Value.ToString();
                txtRazonEdit.Text = DgvEmpresa.CurrentRow.Cells["cnRazonSocial"].Value.ToString();
                cmbDireEdit.Text = DgvEmpresa.CurrentRow.Cells["cnDireccion"].Value.ToString();
                string respuesta5 = await Get.GetHttpTipoEmpresa();
                List<tipoEmpresa> lista5 = JsonConvert.DeserializeObject<List<tipoEmpresa>>(respuesta5);
                cmbTipoEmpEdit.DataSource = lista5;
                cmbTipoEmpEdit.DisplayMember = "tipo_empresa";
                cmbTipoEmpEdit.ValueMember = "id_tipo_empresa";
                cmbTipoEmpEdit.Text = DgvEmpresa.CurrentRow.Cells["cnTipoEmpresa"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private async void btnBusDirc_Click(object sender, EventArgs e)
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
        private void txtDunsEmp_Enter(object sender, EventArgs e)
        {
            if (txtDunsEmp.Text == "Duns Empresa")
            {
                txtDunsEmp.Text = "";
                txtDunsEmp.ForeColor = System.Drawing.Color.Black;

            }
        }
        private void txtDunsEmp_Leave(object sender, EventArgs e)
        {
            if (txtDunsEmp.Text == "")
            {
                txtDunsEmp.Text = "Duns Empresa";
                txtDunsEmp.ForeColor = System.Drawing.Color.DimGray;

            }
        }
        private void txtRazonSocial_Enter(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "Razon social")
            {
                txtRazonSocial.Text = "";
                txtRazonSocial.ForeColor = System.Drawing.Color.Black;

            }
        }
        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "")
            {
                txtRazonSocial.Text = "Razon social";
                txtRazonSocial.ForeColor = System.Drawing.Color.DimGray;

            }
        }
        private void txtDunsEdit_Enter(object sender, EventArgs e)
        {
            if (txtDunsEdit.Text == "Duns Empresa")
            {
                txtDunsEdit.Text = "";
                txtDunsEdit.ForeColor = System.Drawing.Color.Black;

            }
        }
        private void txtDunsEdit_Leave(object sender, EventArgs e)
        {
            if (txtDunsEdit.Text == "")
            {
                txtDunsEdit.Text = "Duns Empresa";
                txtDunsEdit.ForeColor = System.Drawing.Color.DimGray;

            }
        }
        private void txtRazonEdit_Enter(object sender, EventArgs e)
        {
            if (txtRazonEdit.Text == "Razon Social")
            {
                txtRazonEdit.Text = "";
                txtRazonEdit.ForeColor = System.Drawing.Color.Black;

            }
        }
        private void txtRazonEdit_Leave(object sender, EventArgs e)
        {
            if (txtRazonEdit.Text == "")
            {
                txtRazonEdit.Text = "Razon Social";
                txtRazonEdit.ForeColor = System.Drawing.Color.DimGray;

            }
        }
        private void btnLimpiarDire_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            cmbDireEdit.DataSource = lista;
            cmbDireEdit.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private async void btnBuscarDirec_Click(object sender, EventArgs e)
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
    }
}