using EFTEC;
using MercadoChile.Modelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
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
            //List<Usuarios> lista = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta);
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            List<Pais> lista2 = JsonConvert.DeserializeObject<List<Pais>>(respuesta2);            
            List<Empresa> lista5 = JsonConvert.DeserializeObject<List<Empresa>>(respuesta5);
            cmbCargo.DataSource = lista1;
            cmbPais.DataSource = lista2;
            cmbEmpresa.DataSource = lista5;
            lista1.RemoveAt(0);      
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.ValueMember = "id_cargo";
            cmbPais.SelectedItem = null;
            cmbPais.DisplayMember = "nombre_pais";
            cmbPais.ValueMember = "id_pais";
            cmbEmpresa.SelectedItem = null;
            cmbEmpresa.DisplayMember = "razon_social_empresa";
            cmbEmpresa.ValueMember = "id_empresa";
            
            /*cmbElimRut.DataSource = lista;
            cmbElimRut.DisplayMember = "numero_identificacion_usuario";
            cmbElimRut.ValueMember = "numero_identificacion_usuario";
            cmbElimNom.DataSource = lista;
            cmbElimNom.DisplayMember = "nombre_usuario";
            cmbElimNom.ValueMember = "numero_identificacion_usuario";*/
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
            cmbCiudadEdit.DataSource = lista3.Where(x => x.id_region == id_region).ToList();
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
        private async void Buscador_Click(object sender, EventArgs e)
        {
            string correo = txtEditCor.Text;
            string respuesta0 = await GetHttp();
            string respuesta1 = await GetHttp1();
            List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta0);
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            bool Encontrado = false;
            foreach (var list in lista3)
            {
                foreach (var list1 in lista1)
                {

                    if (correo == list.correo_usuario)
                    {

                        txtEditRut.Enabled = false;
                        Encontrado = true;
                        txtEditRut.Text = list.numero_identificacion_usuario;
                        txtEditCont.Text = list.contrasena_usuario;
                        txtEditNomb.Text = list.nombre_usuario;
                        txtEditDir.Text = list.direccion_usuario;
                        txtEditTel.Text = list.telefono_usuario;
                        txtEditCor.Text = list.correo_usuario;
                        lista1.RemoveAt(0);
                        cmbCargoEdit.DataSource = lista1;
                        cmbCargoEdit.DisplayMember = list1.nombre_cargo ;
                        cmbCargoEdit.DisplayMember = "nombre_cargo";
                        break;
                    }
                }
            }
            if (Encontrado == false)
            {
                txtEditRut.Enabled = true;
                MessageBox.Show("rut no existe");
            }

        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                string rut = cmbElimRut.Text;
                Uri myUri = new Uri(baseUri, rut);
                var client = new HttpClient();
                var httpResponse = await client.DeleteAsync(myUri);


                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    MessageBox.Show(result.ToString());
                    this.Hide();

                }


            }
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            string rut = txtEditRut.Text;
            Uri myUri = new Uri(baseUri, rut);
            var client = new HttpClient();
            Usuarios post = new Usuarios()
            {
                numero_identificacion_usuario = rut,
                nombre_usuario = txtEditNomb.Text,
                direccion_usuario = txtEditDir.Text,
                telefono_usuario = txtEditTel.Text,
                correo_usuario = txtEditCor.Text,
                contrasena_usuario = txtEditCont.Text,
                administrador_usuario = '0',
                id_cargo = cmbCargo.SelectedIndex + 2,
                id_empresa = cmbEmpresa.SelectedIndex + 1,
                id_ciudad = cmbCiudad.SelectedIndex + 1,
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



        private async void btnCrear_Click(object sender, EventArgs e)
        {

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
                id_cargo = cmbCargo.SelectedIndex + 2,
                id_empresa = cmbEmpresa.SelectedIndex + 1,
                id_ciudad = cmbCiudad.SelectedIndex + 1,


            };
            var data = JsonSerializer.Serialize<Usuarios>(post2);
        
            HttpContent content =
                new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var valido = validarRut(txtRutUsua.Text);
            if (IsValidEmail(txtCorUsua.Text))
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

                    
                }else

                {
                    MessageBox.Show("rut malo");
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic response = DBApi.Get("http://127.0.0.1:8015/api/usuario/?format=json");
            DgvClientes.DataSource = response;
        }

       
    }
}
