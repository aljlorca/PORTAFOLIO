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
using RestSharp.Extensions;

namespace MercadoChile.Template
{
    public partial class Postulacion : Form
    {
        private string url = "http://127.0.0.1:8000/api_carga/carga_old/";
        Uri baseUri = new Uri("http://127.0.0.1:8000/api_subasta/subasta_aceptar/");
        getPostulacion Get = new getPostulacion();
        public Postulacion()
        {
            InitializeComponent();
        }
        
        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = await Get.GetHttp();
                List<Subasta> lista = JsonConvert.DeserializeObject<List<Subasta>>(respuesta);
                string respuesta2 = await Get.GetHttp2();
                List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
                string respuesta3 = await Get.GetHttp3();
                List<Venta> lista3 = JsonConvert.DeserializeObject<List<Venta>>(respuesta3);
                DgvSubastas.DataSource = lista;
                DgvSubastas.DataSource = (from p in lista
                                          orderby p.id_venta descending
                                          select p).ToList();
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvSubastas.DataSource];
                currencyManager1.SuspendBinding();
                List<string> idVentas = new List<string>();
                foreach (DataGridViewRow fila in DgvSubastas.Rows)
                {
                    foreach (DataGridViewRow fila2 in DgvSubastas.Rows)
                    {
                        if (Convert.ToString(fila2.Cells["cnEstadoS"].Value) == "Aceptada")
                        {
                            string idventa = Convert.ToString(fila2.Cells["cnVenta"].Value);
                            idVentas.Add(idventa);
                            fila2.Visible = false;
                        }
                    
                        else if (idVentas.Contains(fila.Cells["cnVenta"].Value))
                        {
                            fila.Visible = false;
                        }
                    }        
                    foreach (var fila1 in lista2)
                    {
                        fila.Cells["cnCliente"].Value = fila1.nombre_usuario;
                        break;
                    }
                    /*foreach (var fila1 in lista3)
                    {
                        fila.Cells["cnVenta"].Value = fila1.descripcion_venta;
                        break;
                    }*/
                    DgvSubastas.Rows[fila.Index].Cells["cnBoton"].Value = "Aceptar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void Click_Aceptar(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DgvSubastas.CurrentCell.ColumnIndex == 0)
                {
                    foreach (DataGridViewRow fila in DgvSubastas.Rows)
                    {
                        if (fila.Cells["cnIdS"].Value == DgvSubastas.CurrentRow.Cells["cnIdS"].Value)
                        {
                            string id = fila.Cells["cnIdS"].Value.ToString();
                            Subasta post = new Subasta()
                            {
                                id_subasta = id,
                            };
                            if (MessageBox.Show("Desea Publicar esta postulacion para la Venta "
                                   + DgvSubastas.CurrentRow.Cells["cnVenta"].Value, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                            var data = JsonSerializer.Serialize<Subasta>(post);
                            HttpRequestMessage request = new HttpRequestMessage
                            {
                                Content = new StringContent(data, Encoding.UTF8, "application/json"),
                                Method = HttpMethod.Put,
                                RequestUri = new Uri(baseUri, id),
                            };
                            var httpClient = new HttpClient();
                            
                                await httpClient.SendAsync(request);
                                MessageBox.Show("Publicado con Exito");
                                this.OnLoad(e);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}