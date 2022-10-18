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

namespace MercadoChile.Template
{
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }


        DBApi DBApi = new DBApi();
        getEmpresa Get = new getEmpresa();

        Uri baseUri = new Uri("http://127.0.0.1:8005/api/empresa_old/");
        

        
        private async void  Empresa_Carga(object sender, EventArgs e)
        {

            string respuesta2 = await Get.GetHttp2();
            string respuesta5 = await Get.GetHttp5();


            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            
            List<tipoEmpresa> lista5 = JsonConvert.DeserializeObject<List<tipoEmpresa>>(respuesta5);

            cmbPais.DataSource = lista2;
            cmbEmpresa.DataSource = lista5;
            cmbPais.DisplayMember = "nombre_pais";
            cmbPais.ValueMember = "id_pais";
            cmbEmpresa.DisplayMember = "tipo_empresa";
            cmbEmpresa.ValueMember = "id_tipo_empresa";
        }
        private async void cmbPais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id_pais = Convert.ToInt32(((ComboBox)sender).SelectedValue);
            string respuesta3 = await Get.GetHttp3();
            List<Regiones> lista3 = JsonConvert.DeserializeObject<List<Regiones>>(respuesta3);
            cmbRegion.DisplayMember = "nombre_region";
            cmbRegion.ValueMember = "id_region";
            cmbRegion.DataSource = lista3.Where(x => x.id_pais == id_pais).ToList();

        }
        private async void cmbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id_region = Convert.ToInt32(((ComboBox)sender).SelectedValue);

            string respuesta4 = await Get.GetHttp4();
            List<Ciudad> lista3 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);
            cmbCiudad.DisplayMember = "nombre_ciudad";
            cmbCiudad.ValueMember = "id_ciudad";
            cmbCiudad.DataSource = lista3.Where(x => x.id_region == id_region).ToList();
        }
       

        
    
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

            foreach (var list in lista)
            {
                if (list.correo_usuario == txtDunsEdit.Text)
                {

                    int id = list.id_usuario;



                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(baseUri, id.ToString()),
                    };
                    var httpClient = new HttpClient();

                    if (MessageBox.Show("Desea Eliminar" + txtDunsEdit, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        await httpClient.SendAsync(request);
                        this.Hide();
                    }
                    else
                    {
                        txtDunsEdit.Text = "";
                        txtRazonEdit.Text = "";
                        txtDirEdit.Text = "";
                        txtGiroEdit.Text = "";
                        cmbTipoEmpEdit.Text = "";
                        cmbPaisEdit.Text = "";
                        cmbRegionEdit.Text = "";
                        cmbEmpresa.Text = "";
                        cmbCiudad.Text = "";
                    }




                }
            }
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);

            foreach (var list in lista)
            {
                if (list.numero_identificacion_usuario == txtDunsEdit.Text)
                {
                    if (cmbCiudadEdit.Text == "")
                    {
                        MessageBox.Show("ingrese una ciudad");
                    }
                    else
                    {
                        int id = list.id_usuario;

                        int empresa = (int)cmbTipoEmpEdit.SelectedValue;
                        int ciudad = (int)cmbCiudadEdit.SelectedValue;
                        int pais = (int)cmbPaisEdit.SelectedValue;
                        int region = (int)cmbRegionEdit.SelectedValue;


                        Uri myUri = new Uri(baseUri, id.ToString());
                        var client = new HttpClient();
                        Empresas post = new Empresas()
                        {
                            duns_empresa = txtDunsEdit.Text,
                            razon_social_empresa = txtRazonEdit.Text,
                            direccion_empresa = txtDirEdit.Text,
                            giro_empresa = txtGiroEdit.Text,
                            id_pais = pais,
                            id_region = region,
                            id_tipo_empresa = empresa,
                            id_ciudad = ciudad,
                        };
                        var data = JsonSerializer.Serialize<Empresas>(post);
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
            {
                int empresa = (int)cmbEmpresa.SelectedValue;
                int ciudad = (int)cmbCiudad.SelectedValue;
                int pais = (int)cmbPais.SelectedValue;
                int region = (int)cmbRegion.SelectedValue;
                var client = new HttpClient();
                Empresas post2 = new Empresas()
                {

                    duns_empresa = txtDunsEmp.Text,
                    razon_social_empresa = txtRazonSocial.Text,
                    direccion_empresa = txtDirecEmp.Text,
                    giro_empresa = txtGiroEmp.Text,
                    id_pais = pais,
                    id_region = region,
                    id_tipo_empresa = empresa,
                    id_ciudad = ciudad,



                };
                var data = JsonSerializer.Serialize<Empresas>(post2);
                HttpContent content =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync(baseUri, content);
                if (httpResponse.IsSuccessStatusCode)

                {

                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var postResult = JsonSerializer.Deserialize<Usuarios>(result);
                    this.Hide();

                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dynamic response = DBApi.Get("http://127.0.0.1:8005/api/empresa/?format=json");
            DgvEmpresa.DataSource = response;
            string respuesta4 = await Get.GetHttp4();
            List<Ciudad> lista4 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);            
            string respuesta2 = await Get.GetHttp2();
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            string respuesta3 = await Get.GetHttp3();
            List<Regiones> lista3 = JsonConvert.DeserializeObject<List<Regiones>>(respuesta3);
            string respuesta5 = await Get.GetHttp5();
            List<tipoEmpresa> lista5 = JsonConvert.DeserializeObject<List<tipoEmpresa>>(respuesta5);
            this.DgvEmpresa.Columns[0].Visible = false;
            this.DgvEmpresa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewRow fila in DgvEmpresa.Rows)
            {
                foreach (var fila2 in lista4)
                {
                    if (Convert.ToInt32(fila.Cells["cnCiudad"].Value) == fila2.id_ciudad)
                    {
                        fila.Cells["cnCiudad"].Value = fila2.nombre_ciudad;
                        break;
                    }

                }
                foreach (var fila3 in lista3)
                {
                    if (Convert.ToInt32(fila.Cells["cnRegion"].Value) == fila3.id_region)
                    {
                        fila.Cells["cnRegion"].Value = fila3.nombre_region;

                        break;
                    }
                }
                foreach (var fila3 in lista2)
                {
                    if (Convert.ToInt32(fila.Cells["cnPais"].Value) == fila3.id_pais)
                    {
                        fila.Cells["cnPais"].Value = fila3.nombre_pais;

                        break;
                    }
                }
                foreach (var fila3 in lista5)
                {
                    if (Convert.ToInt32(fila.Cells["cnTipoEmpresa"].Value) == fila3.id_tipo_empresa)
                    {
                        fila.Cells["cnTipoEmpresa"].Value = fila3.tipo_empresa;

                        break;
                    }
                }
            }

        }
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            txtDunsEdit.Text = DgvEmpresa.CurrentRow.Cells[1].Value.ToString();
            txtRazonEdit.Text = DgvEmpresa.CurrentRow.Cells[2].Value.ToString();
            txtDirEdit.Text = DgvEmpresa.CurrentRow.Cells[3].Value.ToString();
            txtGiroEdit.Text = DgvEmpresa.CurrentRow.Cells[4].Value.ToString();

            string respuesta4 = await Get.GetHttp4();
            string respuesta5 = await Get.GetHttp5();
            List<Ciudad> lista3 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
            cmbCiudadEdit.DataSource = lista3;
            cmbTipoEmpEdit.DisplayMember = "nombre_cargo";
            cmbTipoEmpEdit.ValueMember = "id_cargo";
            cmbCiudadEdit.DisplayMember = "nombre_ciudad";
            cmbCiudadEdit.ValueMember = "id_ciudad";
            cmbTipoEmpEdit.Text = DgvEmpresa.CurrentRow.Cells[6].Value.ToString();
            cmbCiudadEdit.Text = DgvEmpresa.CurrentRow.Cells[8].Value.ToString();
            string respuesta2 = await Get.GetHttp2();
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            cmbPaisEdit.DataSource = lista2;
            cmbPaisEdit.DisplayMember = "nombre_pais";
            cmbPaisEdit.ValueMember = "id_pais";
        }
    }
}