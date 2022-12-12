using Datos;
using FontAwesome.Sharp;
using MercadoChile.Modelos;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MercadoChile.Form1;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MercadoChile.Template
{
    
    public partial class Imagenes : Form
    {
        getApi Get = new getApi();
        Uri baseUri = new Uri("http://127.0.0.1:8000/api_producto/producto_old/");
        public Imagenes(string id,string name, Image img)
        {
            InitializeComponent ();
            txtId.Text = id;
            txtNomProd.Text = name;
            txtNomProd.Enabled = false;
            txtSaldo.Enabled = false;
            pictureBox1.Image = img;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try { 
            string respuesta = await Get.GetHttpProducto();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            foreach (var list in lista)
            {
                    if (list.id_producto == txtId.Text)
                    {
                        string id = list.id_producto;
                        Uri myUri = new Uri(baseUri, id);
                        var client = new HttpClient();
                        Producto post = new Producto()
                        {
                            id_producto = id,
                            saldo_producto = txtSaldo.Text,
                        };
                        var data = JsonSerializer.Serialize<Producto>(post);
                        HttpContent content =
                            new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                        var httpResponse = await client.PutAsync(myUri, content);


                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var result = await httpResponse.Content.ReadAsStringAsync();
                            MessageBox.Show("Producto distribuido correctamente");
                            this.Hide();

                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
