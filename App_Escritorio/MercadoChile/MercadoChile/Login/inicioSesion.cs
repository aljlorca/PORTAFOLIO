using MercadoChile.Modelos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Media3D;
using System.Windows.Markup;

namespace MercadoChile
{
    public partial class inicioSesion : Form
    {
        Form1 form1;
        private string url = "http://127.0.0.1:8004/api/usuario_auth/";
        public inicioSesion()
        {
            InitializeComponent();


        }


        private async void iniciar_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            Login post = new Login()
            {
                correo_usuario = txtCorreo.Text,
                contrasena_usuario = txtContraseña.Text
            };
            var respuesta = await client.PostAsJsonAsync(url, post);
            var cuerpo = await respuesta.Content.ReadAsStringAsync();
            
            if (cuerpo.ToString().Contains("Success") == true)
            {
                if(cuerpo.ToString().Contains("Administrador")==true)
                {
                    form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ingrese un usuario Administrador");
                }
            }
            else
            {
                MessageBox.Show("ingrese un usuario");
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

        private void inicioSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciar.PerformClick();
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtContraseña.Focus();
                e.Handled = true;
            }
        }
    }

}

