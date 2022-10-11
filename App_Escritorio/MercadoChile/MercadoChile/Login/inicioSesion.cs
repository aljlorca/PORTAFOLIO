using MercadoChile.Modelos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MercadoChile
{
    public partial class inicioSesion : Form
    {
        Form1 form1;
        private string url = "http://127.0.0.1:8004/api/usuario_desktop/";
        public inicioSesion()
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

        private async void iniciar_Click(object sender, EventArgs e)
        {
            string Correo = txtCorreo.Text;
            string Pass = txtContraseña.Text;
            string respuesta1 = await GetHttp();
            List<Login> lista1 = JsonConvert.DeserializeObject<List<Login>>(respuesta1);
            bool logeoExitoso = false;
            foreach (var list in lista1)
            {

                if (Pass == list.contrasena_usuario && Correo == list.correo_usuario)
                {
                    logeoExitoso = true;
                    form1 = new Form1();
                    form1.Show();
                    this.Hide();

                    break;
                }
            }
            if (logeoExitoso == false)
            {
                MessageBox.Show("datos incorrectos");
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtrut_admin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontraseña_admin_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtrut_admin_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "USUARIO")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.LightGray;
            }
        }

        private void txtrut_admin_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "USUARIO";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        private void txtcontraseña_admin_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "**********")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
            }
        }

        private void txtcontraseña_admin_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "**********")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

