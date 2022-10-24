﻿using Amazon.Runtime.Internal;
using Datos;
using MercadoChile.Modelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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


        Uri baseUri = new Uri("http://127.0.0.1:8016/api/usuario_old/");
        


        public Usuario()
        {
            InitializeComponent();
        }

        #region ComboBox
        private async void Clientes_Carga(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            string respuesta1 = await Get.GetHttp1();
            string respuesta2 = await Get.GetHttp2();
            string respuesta5 = await Get.GetHttp5();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
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
            string respuesta3 = await Get.GetHttp3();
            List<Regiones> lista3 = JsonConvert.DeserializeObject<List<Regiones>>(respuesta3);
            cmbRegion.DisplayMember = "nombre_region";
            cmbRegion.ValueMember = "id_region";
            cmbRegion.DataSource = lista3.Where(x => x.id_pais == id_pais).ToList();
            cmbRegionEdit.DisplayMember = "nombre_region";
            cmbRegionEdit.ValueMember = "id_region";
            cmbRegionEdit.DataSource = lista3.Where(x => x.id_pais == id_pais).ToList();


        }
        private async void cmbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id_region = Convert.ToInt32(((ComboBox)sender).SelectedValue);

            string respuesta4 = await Get.GetHttp4();
            List<Ciudad> lista3 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);
            cmbCiudad.DisplayMember = "nombre_ciudad";
            cmbCiudad.ValueMember = "id_ciudad";
            cmbCiudad.DataSource = lista3.Where(x => x.id_region == id_region).ToList();
            cmbCiudadEdit.DisplayMember = "nombre_ciudad";
            cmbCiudadEdit.ValueMember = "id_ciudad";
            cmbCiudadEdit.DataSource = lista3.Where(x => x.id_region == id_region).ToList();
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
            string respuesta = await Get.GetHttp();
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
                        int pais = (int)cmbPaisEdit.SelectedValue;
                        int region = (int)cmbRegionEdit.SelectedValue;
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
                            id_pais = pais,
                            id_region = region,
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
                int pais = (int)cmbPais.SelectedValue;
                int region = (int)cmbRegion.SelectedValue;
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
                    id_ciudad = ciudad,
                    id_region = region,
                    id_pais = pais,
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
            dynamic response = DBApi.Get("http://127.0.0.1:8016/api/usuario/?format=json");
            DgvClientes.DataSource = response;
            string respuesta1 = await Get.GetHttp1();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            string respuesta4 = await Get.GetHttp4();
            List<Ciudad> lista4 = JsonConvert.DeserializeObject<List<Ciudad>>(respuesta4);
            string respuesta5 = await Get.GetHttp5();
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
            string respuesta = await Get.GetHttp();
            List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
            string respuesta2 = await Get.GetHttp2();
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            string respuesta3 = await Get.GetHttp3();
            List<Regiones> lista3 = JsonConvert.DeserializeObject<List<Regiones>>(respuesta3);
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
                foreach (var fila2 in lista4)
                {
                    if (Convert.ToInt32(fila.Cells["cnCiudad"].Value) == fila2.id_ciudad)
                    {
                        fila.Cells["cnCiudad"].Value = fila2.nombre_ciudad;
                        break;
                    }

                }
                foreach (var fila1 in lista2)
                {

                    if (Convert.ToInt32(fila.Cells["cnPais"].Value) == fila1.id_pais)
                    {
                        fila.Cells["cnPais"].Value = fila1.nombre_pais;
                        break;
                    }
                }
                foreach (var fila1 in lista3)
                {

                    if (Convert.ToInt32(fila.Cells["cnRegion"].Value) == fila1.id_region)
                    {
                        fila.Cells["cnRegion"].Value = fila1.nombre_region;
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
            txtRutEdit.Text = DgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtNomEdit.Text = DgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtDirEdit.Text = DgvClientes.CurrentRow.Cells[3].Value.ToString();
            txtTeleEdit.Text = DgvClientes.CurrentRow.Cells[4].Value.ToString();
            txtCorEdit.Text = DgvClientes.CurrentRow.Cells[5].Value.ToString();
            
            string respuesta1 = await Get.GetHttp1();
            string respuesta5 = await Get.GetHttp5();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            string respuesta2 = await Get.GetHttp2();
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);
            List<Empresas> lista5 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta5);
            lista1.RemoveAt(0);
            cmbCargoEdit.DataSource = lista1;
           
            cmbEmpresaEdit.DataSource = lista5;
            cmbCargoEdit.DisplayMember = "nombre_cargo";
            cmbCargoEdit.ValueMember = "id_cargo";
            cmbEmpresaEdit.DisplayMember = "razon_social_empresa";
            cmbEmpresaEdit.ValueMember = "id_empresa";
            cmbPaisEdit.DataSource = lista2;
            cmbPaisEdit.DisplayMember = "nombre_pais";
            cmbPaisEdit.ValueMember = "id_pais";
            cmbCargoEdit.Text = DgvClientes.CurrentRow.Cells[7].Value.ToString();
            cmbEmpresaEdit.Text = DgvClientes.CurrentRow.Cells[8].Value.ToString();
            cmbCiudadEdit.Text = DgvClientes.CurrentRow.Cells[9].Value.ToString();
            cmbRegionEdit.Text = DgvClientes.CurrentRow.Cells[10].Value.ToString();
            cmbPaisEdit.Text = DgvClientes.CurrentRow.Cells[11].Value.ToString();
            
            
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtRutUsua_TextChanged(object sender, EventArgs e)
        {

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
            if (txtNombreUsua.Text == "")
            {
                txtNombreUsua.Text = "Nombre Cliente";
                txtNombreUsua.ForeColor = Color.DimGray;

            }
        }

        private void txtNombreUsua_Leave(object sender, EventArgs e)
        {
            if (txtNombreUsua.Text == "Nombre Cliente")
            {
                txtNombreUsua.Text = "";
                txtNombreUsua.ForeColor = Color.Black;

            }
        }

        private void txtDirecUsua_Enter(object sender, EventArgs e)
        {
            if (txtDirecUsua.Text == "Direccion")
            {
                txtDirecUsua.Text = "";
                txtDirecUsua.ForeColor = Color.Black;

            }
        }

        private void txtDirecUsua_Leave(object sender, EventArgs e)
        {
            if (txtDirecUsua.Text == "")
            {
                txtDirecUsua.Text = "Direccion";
                txtDirecUsua.ForeColor = Color.DimGray;

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

        private void tabPage1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Leave(object sender, EventArgs e)
        {

        }

        private void cmbPais_Enter(object sender, EventArgs e)
        {

        }

        private void cmbPais_Leave(object sender, EventArgs e)
        {

        }

        private void cmbRegion_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRegion_Leave(object sender, EventArgs e)
        {

        }

        private void cmbCiudad_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCiudad_Leave(object sender, EventArgs e)
        {

        }

        private void cmbEmpresa_Enter(object sender, EventArgs e)
        {

        }

        private void cmbEmpresa_Leave(object sender, EventArgs e)
        {

        }

        private void cmbCargo_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCargo_Leave(object sender, EventArgs e)
        {

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

        private void txtDirEdit_Enter(object sender, EventArgs e)
        {
            if (txtDirEdit.Text == "Direccion")
            {
                txtDirEdit.Text = "";
                txtDirEdit.ForeColor = Color.Black;

            }
        }

        private void txtDirEdit_Leave(object sender, EventArgs e)
        {
            if (txtDirEdit.Text == "")
            {
                txtDirEdit.Text = "Direccion";
                txtDirEdit.ForeColor = Color.DimGray;

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
#endregion