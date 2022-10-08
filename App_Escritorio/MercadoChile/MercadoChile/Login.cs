using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoChile
{
    public partial class Login : Form
    {
        DBApi dBApi = new DBApi();
        private string url = "http://127.0.0.1:8001/api/Administrador/?format=json";
        public Login()
        {
            InitializeComponent();
        }
        



        private void iniciar_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();

            if (contraseña_admin.Text == admin.contrasena_administrador && nombre_admin.Text == admin.nombre_administrador)
            {

               
                string json = "{\"nombre_administrador\": \"" + nombre_admin.Text +
                "\",\"contrasena_administrador\":\"" + contraseña_admin.Text + "\"";
                dynamic respuesta = dBApi.Post("http://127.0.0.1:8001/api/Administrador/?format=json", json);
                    

                    MessageBox.Show("successfull");
                }else
                    MessageBox.Show("error");
                {
                
                }

            }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
    public class Administrador
    {
        public int rut_administrador { get; set; }
        public string nombre_administrador { get; set; }
        public string direccion_administrador { get; set; }
        public int telefono_administrador { get; set; }
        public string correo_administrador { get; set; }
        public string contrasena_administrador { get; set; }
        public int cargo_id_cargo { get; set; }



    }
}

