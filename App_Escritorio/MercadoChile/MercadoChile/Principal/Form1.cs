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
using System.Runtime.InteropServices;
using MercadoChile.Modelos;
using MercadoChile.Template;

namespace MercadoChile
{
    public partial class Form1 : Form
    {
        DBApi dBApi = new DBApi();
        inicioSesion iniciosesion;

        private string url = "http://127.0.0.1:8000/api/cargo/cargo/?format=json";
        public Form1()
        {
            InitializeComponent();
          
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string respuesta1 = await GetHttp();
            List<Cargo> lista1 = JsonConvert.DeserializeObject<List<Cargo>>(respuesta1);
            comboBox1.DataSource = lista1;
            comboBox1.DisplayMember = "nombre_cargo";
            comboBox1.ValueMember = "id";
        }
        private async Task<string> GetHttp() 
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public class Cargo 
        {
            public int id { get; set; }
            public string nombre_cargo { get; set; }
            public string descripcion { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string json = "{\"nombre_cargo\": \""+txtCargo.Text+"\"}";

            dynamic respuesta = dBApi.Post("http://127.0.0.1:8000/api/cargo/", json);

            MessageBox.Show(respuesta.ToString());
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 85;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconRestaurar.Visible = true;
            iconMaximizar.Visible = false;
        }

        private void iconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconRestaurar.Visible = false;
            iconMaximizar.Visible = true;
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void AbrirForm(object FormHijo) 
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForm(new Usuario());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirForm(new Empresa());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new Cargos());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirForm(new Contrato());
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirForm(new Publicacion());
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForm(new Postulacion());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirForm(new Procesos());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            iniciosesion = new inicioSesion();
            iniciosesion.Show();
            this.Hide();
        }
    }
}
