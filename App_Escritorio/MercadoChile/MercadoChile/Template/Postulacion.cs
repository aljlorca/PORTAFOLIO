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

namespace MercadoChile.Template
{
    public partial class Postulacion : Form
    {
        private string url = "http://127.0.0.1:8014/api/subasta/";
        private string url2 = "http://127.0.0.1:8016/api/usuario/";
        private string url3 = "http://127.0.0.1:8017/api/venta/";
        private string url4 = "http://127.0.0.1:8001/api/carga_old/";
        public Postulacion()
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

        private async void btnListar_Click(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Subasta> lista = JsonConvert.DeserializeObject<List<Subasta>>(respuesta);
            string respuesta2 = await GetHttp2();
            List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
            string respuesta3 = await GetHttp3();
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
        private async void btnPublicar_Click(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<Subasta> lista = JsonConvert.DeserializeObject<List<Subasta>>(respuesta);
            string respuesta2 = await GetHttp2();
            List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
            foreach (var list in lista)
            {
                foreach (var list2 in lista2)
                {
                    if (list.monto_subasta == Convert.ToInt32(txtMonto.Text))
                    {
                        int id_subasta = list.id_subasta;
                        if(list2.nombre_usuario == txtTransportista.Text)
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
                            var httpResponse = await client.PostAsync(url4, content);
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
        private void btnSelSub_Click(object sender, EventArgs e)
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

        
    }
    }

