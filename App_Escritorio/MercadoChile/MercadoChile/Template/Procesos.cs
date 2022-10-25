using Datos;
using iTextSharp.text.html.simpleparser;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Net.WebRequestMethods;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace MercadoChile.Template
{

    public partial class Procesos : Form
    {
        Uri baseUri = new Uri("http://127.0.0.1:8009/api/postulacion_old/");
        getProcesos Get = new getProcesos();
        public Procesos()
        {
            InitializeComponent();
            DgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Aceptar";
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            string respuesta2 = await Get.GetHttp2();
            List<Calidad> lista2 = JsonConvert.DeserializeObject<List<Calidad>>(respuesta2);
            string respuesta3 = await Get.GetHttp3();
            List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta3);
            string respuesta4 = await Get.GetHttp4();
            List<Pedido> lista4 = JsonConvert.DeserializeObject<List<Pedido>>(respuesta4);
            DgvProducto.DataSource = lista;
            this.DgvProducto.Columns[7].Visible = false;
            cnImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvProducto.DataSource];
            currencyManager1.SuspendBinding();
            foreach (DataGridViewRow fila in DgvProducto.Rows)
            {
                foreach (var fila1 in lista)
                {
                    if (Convert.ToInt32(fila.Cells["cnSaldo"].Value) == 1)
                    {
                        fila.Visible = false;
                        currencyManager1.ResumeBinding();
                        break;

                    }
                }

                string urlss = fila.Cells["cnUrl"].Value.ToString();
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(urlss);
                MemoryStream ms = new MemoryStream(bytes);
                Image img = Image.FromStream(ms);
                DgvProducto.Rows[fila.Index].Cells["cnImagen"].Value = img;
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

        private void DgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = DgvProducto.SelectedRows[0].Cells["cnNomProd"].Value.ToString();
            Image img = (Image)DgvProducto.SelectedRows[0].Cells["cnImagen"].Value;
            Imagenes i = new Imagenes(name, img);
            this.Hide();
            i.Show();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp5();
            List<Postul> lista = JsonConvert.DeserializeObject<List<Postul>>(respuesta);
            DgvPostulacion.DataSource = lista;
            DgvPostulacion.DataSource = (from p in lista
                                         orderby p.id_venta descending
                                         select p).ToList();
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvPostulacion.DataSource];
            currencyManager1.SuspendBinding();
            foreach (DataGridViewRow fila in DgvPostulacion.Rows)
            {
                foreach (var list in lista)
                {
                    if (fila.Cells["cnEstadoF"].Value.ToString() == "1")
                    {
                        fila.Visible = false;
                        currencyManager1.ResumeBinding();
                        break;
                    }
                }
                DgvPostulacion.Rows[fila.Index].Cells["cnBoton"].Value = "Aceptar";

            }
        }

        private async void Click_Aceptar(object sender, DataGridViewCellEventArgs e)
        {

            if (DgvPostulacion.CurrentCell.ColumnIndex == 0)
            {
                foreach (DataGridViewRow fila in DgvPostulacion.Rows)
                {
                    if (fila.Cells["cnIdP"].Value == DgvPostulacion.CurrentRow.Cells[1].Value)
                    {
                        string id = fila.Cells["cnIdP"].Value.ToString();
                        Console.WriteLine(id);
                        Postul post = new Postul()
                        {
                            id_postulacion = id,
                        };
                        var data = JsonSerializer.Serialize<Postul>(post);
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Content = new StringContent(data, Encoding.UTF8, "application/json"),
                            Method = HttpMethod.Put,
                            RequestUri = new Uri(baseUri, id),
                        };
                        var httpClient = new HttpClient();
                        if (MessageBox.Show("Desea Publicar esta postulacion del Proveedor "
                               + DgvPostulacion.CurrentRow.Cells[2].Value, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            await httpClient.SendAsync(request);
                            this.Hide();
                        }
                    }
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow fila in DgvPostulacion.Rows)
            {
                int i = DgvPostulacion.SelectedCells[0].RowIndex;
                if (fila.Cells["cnIdP"].Value == DgvPostulacion.Rows[i].Cells[1].Value)
                {
                    string id = fila.Cells["cnIdP"].Value.ToString();
                    Console.WriteLine(id);
                    Postul post = new Postul()
                    {
                        id_postulacion = id,
                    };
                    var data = JsonSerializer.Serialize<Postul>(post);
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Content = new StringContent(data, Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(baseUri, id),
                    };
                    var httpClient = new HttpClient();
                    if (MessageBox.Show("Desea eliminar esta postulacion del Proveedor "
                           + DgvPostulacion.CurrentRow.Cells[2].Value, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        await httpClient.SendAsync(request);
                        this.Hide();
                    }
                }
            }
        }
    }
}
