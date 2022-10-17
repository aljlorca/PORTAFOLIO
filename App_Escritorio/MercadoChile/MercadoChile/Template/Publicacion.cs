using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Negocio;

using MercadoChile.Modelos;
using Amazon.Runtime.Internal;
using System.Net.Http;
using System.Windows.Documents;
using static MercadoChile.Form1;
using Xamarin.Forms;
using Image = System.Drawing.Image;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Data.SqlTypes;
using System.Windows.Controls;

namespace MercadoChile.Template
{
    public partial class Publicacion : Form
    {
        private string url = "http://127.0.0.1:8010/api/producto/?format=json";
        private string url2 = "http://127.0.0.1:8000/api/calidad/";
        private string url3 = "http://127.0.0.1:8016/api/usuario/";
        private string url4 = "http://127.0.0.1:8008/api/pedido/";
        private string url5 = "http://127.0.0.1:8008/api/pedido_old/";
        public Publicacion()
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
        private async void btnListar_Click(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            string respuesta2 = await GetHttp2();
            List<Calidad> lista2 = JsonConvert.DeserializeObject<List<Calidad>>(respuesta2);
            string respuesta3 = await GetHttp3();
            List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta3);
            string respuesta4 = await GetHttp4();
            List<Pedido> lista4 = JsonConvert.DeserializeObject<List<Pedido>>(respuesta4);
            DgvProducto.DataSource = lista;
            this.DgvProducto.Columns[1].Visible = false;
            this.DgvProducto.Columns[7].Visible = false;
            cnImagen1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvProducto.DataSource];
            currencyManager1.SuspendBinding();
            foreach (DataGridViewRow fila in DgvProducto.Rows)
            {
                foreach (var fila1 in lista4)
                {
                    if (Convert.ToInt32(fila.Cells["cnId"].Value) == fila1.id_pedido)
                    {
                        fila.Visible = false;
                        currencyManager1.ResumeBinding();
                        break;
                    }
                }
                string urlss = fila.Cells["cnImagen"].Value.ToString();
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(urlss);
                MemoryStream ms = new MemoryStream(bytes);
                Image img = Image.FromStream(ms);
                DgvProducto.Rows[fila.Index].Cells["cnImagen1"].Value = img;
                foreach (var fila1 in lista2)
                {
                    fila.Cells["cnCalidad"].Value = fila1.descripcion_calidad;
                    break;
                }
                foreach (var fila1 in lista3)
                {
                    fila.Cells["cnProveedor"].Value = fila1.nombre_usuario;
                    break;
                }
            }
        }
        private void btnSelProd_Click(object sender, EventArgs e)
        {
            txtNomProd.Text = DgvProducto.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = DgvProducto.CurrentRow.Cells[3].Value.ToString();
            txtPrecio.Text = DgvProducto.CurrentRow.Cells[4].Value.ToString();
            txtSaldoProd.Text = DgvProducto.CurrentRow.Cells[7].Value.ToString();
            txtCalidad.Text = DgvProducto.CurrentRow.Cells[8].Value.ToString();
            txtProveedor.Text = DgvProducto.CurrentRow.Cells[9].Value.ToString();
        }
        private async void btnPublicar_Click(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            foreach (var list in lista)
            {
                if (list.nombre_producto == txtNomProd.Text)
                {
                    int id = list.id_producto;
                    var client = new HttpClient();
                    Pedido post2 = new Pedido()
                    {
                        id_pedido = id,
                        fecha_pedido = DateTime.Now.ToString("yyyy-MM-dd"),
                        id_venta = "",
                        id_producto = id,
                    };
                    var data = JsonSerializer.Serialize<Pedido>(post2);
                    HttpContent content =
                        new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    var httpResponse = await client.PostAsync(url5, content);
                    if (MessageBox.Show("Desea Publicar el Producto " + txtNomProd.Text, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var result = await httpResponse.Content.ReadAsStringAsync();
                            var postResult = JsonSerializer.Deserialize<Pedido>(result);
                            this.Hide();
                        }
                    }
                    else
                    {
                        txtNomProd.Text = "";
                        txtCantidad.Text = "";
                        txtCalidad.Text = "";
                        txtPrecio.Text = "";
                        txtProveedor.Text = "";
                        txtSaldoProd.Text = "";
                    }
                }
            }
        }
    }
}

