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
    public partial class Cargos : Form
    {
        DBApi dBApi = new DBApi();
        public Cargos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string json = "{\"nombre_cargo\": \"" + txtCargo.Text + "\"}";

            dynamic respuesta = dBApi.Post("http://127.0.0.1:8002/api/cargo/?format=json", json);

            MessageBox.Show(respuesta.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCargo_Enter(object sender, EventArgs e)
        {
            if (txtCargo.Text == "Nombre Cargo")
            {
                txtCargo.Text = "";
                txtCargo.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtCargo_Leave(object sender, EventArgs e)
        {
            if (txtCargo.Text == "")
            {
                txtCargo.Text = "Nombre Cargo";
                txtCargo.ForeColor = System.Drawing.Color.DimGray;

            }
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cargos_Load(object sender, EventArgs e)
        {

        }
    }
}
