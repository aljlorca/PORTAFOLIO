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
        Uri Venta = new Uri("http://127.0.0.1:8000/api_venta/venta_reporte/");
        Uri baseUri = new Uri("http://127.0.0.1:8000/api_subasta/subasta_aceptar/");
        getApi Get = new getApi();
        public Postulacion()
        {
            InitializeComponent();
        }
        
        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = await Get.GetHttpSubasta();
                List<Subasta> lista = JsonConvert.DeserializeObject<List<Subasta>>(respuesta);
                string respuesta2 = await Get.GetHttpUsuario();
                List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
                string respuesta3 = await Get.GetHttpVenta();
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
                            Console.WriteLine(idventa);
                            fila2.Visible = false;
                        }
                        else if (idVentas.Contains(fila.Cells["cnVenta"].Value))
                        {
                            fila.Visible = false;
                        }
                    }

                    foreach (var fila1 in lista2)
                    {
                        if (Convert.ToString(fila.Cells["cnCliente"].Value) == fila1.id_usuario)
                        {
                            fila.Cells["cnCliente"].Value = fila1.nombre_usuario;
                            break;
                        }
                    }
                    foreach (var fila1 in lista3)
                    {
                        if (Convert.ToString(fila.Cells["cnVenta"].Value) == fila1.id_venta)
                        {
                            fila.Cells["cnVentaa"].Value = fila1.descripcion_venta;
                            break;
                        }
                    }
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
                            string idVenta = fila.Cells["cnVenta"].Value.ToString();
                            if (MessageBox.Show("Desea Publicar esta postulacion para la Venta "
                                   + DgvSubastas.CurrentRow.Cells["cnVenta"].Value, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                HttpRequestMessage request = new HttpRequestMessage
                                {
                                    Method = HttpMethod.Put,
                                    RequestUri = new Uri(baseUri, id),
                                };
                                Venta post = new Venta()
                                {
                                    id_venta = idVenta,
                                };
                                var data = JsonSerializer.Serialize<Venta>(post);
                                HttpRequestMessage requestVenta = new HttpRequestMessage
                                {
                                    Content = new StringContent(data, Encoding.UTF8, "application/json"),
                                    Method = HttpMethod.Post,
                                    RequestUri = new Uri(Venta, idVenta),
                                };                              
                                var httpClient = new HttpClient();
                                await httpClient.SendAsync(request);
                                await httpClient.SendAsync(requestVenta);
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