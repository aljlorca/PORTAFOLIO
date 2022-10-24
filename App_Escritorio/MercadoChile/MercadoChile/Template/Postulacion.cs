using MercadoChile.Modelos;
using Negocio;
using Newtonsoft.Json;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Datos;
using static System.Net.WebRequestMethods;

namespace MercadoChile.Template
{
    public partial class Postulacion : Form
    {
        private string url = "http://127.0.0.1:8001/api/carga_old/";
        private string url2 = "http://127.0.0.1:8001/api/subasta_old/";
        getPostulacion Get = new getPostulacion();
        public Postulacion()
        {
            InitializeComponent();
        }


        private async void btnListarSub_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Subasta> lista = JsonConvert.DeserializeObject<List<Subasta>>(respuesta);
            string respuesta2 = await Get.GetHttp2();
            List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
            string respuesta3 = await Get.GetHttp3();
            List<Venta> lista3 = JsonConvert.DeserializeObject<List<Venta>>(respuesta3);
            DgvSubasta.DataSource = lista;
            foreach (DataGridViewRow fila in DgvSubasta.Rows)
            {
                foreach (var fila1 in lista2)
                {
                    fila.Cells["cnTransportista"].Value = fila1.nombre_usuario;
                    break;
                }
                foreach (var fila1 in lista3)
                {
                    fila.Cells["cnVenta"].Value = fila1.descripcion_venta;
                    break;
                }
            }
        }
        private async void btnPublicar_Click_1(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Subasta> lista = JsonConvert.DeserializeObject<List<Subasta>>(respuesta);
            string respuesta2 = await Get.GetHttp2();
            List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
            foreach (var list in lista)
            {
                foreach (var list2 in lista2)
                {
                    if (list.monto_subasta == Convert.ToInt32(txtMonto.Text))
                    {
                        int id_subasta = list.id_subasta;
                        if (list2.nombre_usuario == txtTransportista.Text)
                        {
                            int id_usuario = list2.id_usuario;
                            var client = new HttpClient();
                            Carga post2 = new Carga()
                            {
                                capacidad_carga = txtCapacidad.Text,
                                refrigeracion_carga = txtRefrigeracion.Text,
                                tamano_carga = txtTamaño.Text,
                                id_subasta = id_subasta,
                                id_usuario = id_usuario,
                            };
                            var data = JsonSerializer.Serialize<Carga>(post2);
                            HttpContent content =
                                new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                            var httpResponse = await client.PostAsync(url, content);
                            if (MessageBox.Show("Desea Publicar seleccionar esta subasta del transportista "
                                + txtTransportista.Text, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (httpResponse.IsSuccessStatusCode)
                                {
                                    var result = await httpResponse.Content.ReadAsStringAsync();
                                    var postResult = JsonSerializer.Deserialize<Carga>(result);
                                    this.Hide();
                                }
                            }
                            else
                            {
                                txtCapacidad.Text = "";
                                txtRefrigeracion.Text = "";
                                txtTamaño.Text = "";
                                txtTransportista.Text = "";
                                txtMonto.Text = "";
                            }
                        }
                    }
                }
            }
        }
        private void btnSelSub_Click_1(object sender, EventArgs e)
        {
            txtMonto.Text = DgvSubasta.CurrentRow.Cells[1].Value.ToString();
            txtTransportista.Text = DgvSubasta.CurrentRow.Cells[4].Value.ToString();
        }
        private void txtBusVenta_TextChanged(object sender, EventArgs e)
        {
            DgvSubasta.CurrentCell = null;
            foreach (DataGridViewRow fila in DgvSubasta.Rows)
            {
                fila.Visible = fila.Cells["cnVenta"].Value.ToString().ToUpper().Contains(txtBusVenta.Text.ToUpper());
            }

        }

        private async void btnListarVent_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp3();
            List<Venta> lista = JsonConvert.DeserializeObject<List<Venta>>(respuesta);
            string respuesta2 = await Get.GetHttp2();
            List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
            DgvVenta.DataSource = lista;
            foreach (DataGridViewRow fila in DgvSubasta.Rows)
            {
                foreach (var fila1 in lista2)
                {
                    fila.Cells["cnClienteExterno"].Value = fila1.nombre_usuario;
                    break;
                }
            }
        }

        private void btnSelccVenta_Click(object sender, EventArgs e)
        {
            txtDescVenta.Text = DgvSubasta.CurrentRow.Cells[1].Value.ToString();
        }

        private async void btnIngresarSubasta_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp3();
            List<Venta> lista = JsonConvert.DeserializeObject<List<Venta>>(respuesta);
            foreach (var list in lista)
            {
                if (txtDescVenta.Text == list.descripcion_venta)
                {
                    int id_venta = list.id_venta;
                    var client = new HttpClient();
                    Subasta post2 = new Subasta()
                    {
                        monto_subasta = 0,
                        id_venta = id_venta,
                        fecha_subasta = DateTime.Now,
                        id_usuario = list.id_usuario,

                    };
                    var data = JsonSerializer.Serialize<Subasta>(post2);
                    HttpContent content =
                        new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    var httpResponse = await client.PostAsync(url, content);
                    if (MessageBox.Show("Desea Publicar seleccionar esta subasta del transportista "
                        + txtTransportista.Text, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var result = await httpResponse.Content.ReadAsStringAsync();
                            var postResult = JsonSerializer.Deserialize<Subasta>(result);
                            this.Hide();
                        }
                    }
                    else
                    {
                        txtDescVenta.Text = "";

                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            if (txtMonto.Text == "Monto")
            {
                txtMonto.Text = "";
                txtMonto.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (txtMonto.Text == "")
            {
                txtMonto.Text = "Monto";
                txtMonto.ForeColor = System.Drawing.Color.DimGray;

            }
        }

        private void txtTransportista_Enter(object sender, EventArgs e)
        {
            if (txtTransportista.Text == "Transportista")
            {
                txtTransportista.Text = "";
                txtTransportista.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtTransportista_Leave(object sender, EventArgs e)
        {
            if (txtTransportista.Text == "")
            {
                txtTransportista.Text = "Transportista";
                txtTransportista.ForeColor = System.Drawing.Color.DimGray;

            }
        }

        private void txtCapacidad_Enter(object sender, EventArgs e)
        {
            if (txtCapacidad.Text == "Capacidad")
            {
                txtCapacidad.Text = "";
                txtCapacidad.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtCapacidad_Leave(object sender, EventArgs e)
        {
            if (txtCapacidad.Text == "Capacidad")
            {
                txtCapacidad.Text = "";
                txtCapacidad.ForeColor = System.Drawing.Color.DimGray;

            }
        }

        private void txtRefrigeracion_Enter(object sender, EventArgs e)
        {
            if (txtRefrigeracion.Text == "Agregar Refrigeracion")
            {
                txtRefrigeracion.Text = "";
                txtRefrigeracion.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtRefrigeracion_Leave(object sender, EventArgs e)
        {
            if (txtRefrigeracion.Text == "")
            {
                txtRefrigeracion.Text = "Agregar Refrigeracion";
                txtRefrigeracion.ForeColor = System.Drawing.Color.DimGray;

            }
        }

        private void txtTamaño_Enter(object sender, EventArgs e)
        {
            if (txtTamaño.Text == "Tamaño")
            {
                txtTamaño.Text = "";
                txtTamaño.ForeColor = System.Drawing.Color.Black;

            }

        }

        private void txtTamaño_Leave(object sender, EventArgs e)
        {
            if (txtTamaño.Text == "")
            {
                txtTamaño.Text = "Tamaño";
                txtTamaño.ForeColor = System.Drawing.Color.DimGray;

            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


