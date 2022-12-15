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
        Uri baseUri = new Uri("http://127.0.0.1:8000/api/postulacion_old/");
        Uri newUri = new Uri("http://127.0.0.1:8000/api_producto/producto_best/");
        getApi Get = new getApi();
        public Procesos()
        {
            InitializeComponent();
            //DgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string respuesta = await Get.GetHttpVenta();
                List<Venta> lista = JsonConvert.DeserializeObject<List<Venta>>(respuesta);
                DgvProducto.DataSource = lista;
                DgvProducto.DataSource = (from p in lista
                                          orderby p.id_venta descending
                                          select p).ToList();
                string respuestaUsuario = await Get.GetHttpUsuario();
                List<Usuarios> listaUsuario = JsonConvert.DeserializeObject<List<Usuarios>>(respuestaUsuario);
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvProducto.DataSource];
                currencyManager1.SuspendBinding();
                foreach (DataGridViewRow fila in DgvProducto.Rows)
                {
                    foreach (var usuario in listaUsuario)

                        if (Convert.ToString(fila.Cells["cnClientee"].Value) == usuario.id_usuario)
                        {
                            fila.Cells["cnClientee"].Value = usuario.nombre_usuario;
                            break;
                        }
                        
                    if (fila.Cells["cnEstadoV"].Value.ToString() != "licitacion") 
                    { 
                        fila.Visible = false;
                    }
                    if (fila.Cells["cnTipoVenta"].Value.ToString() == "1")
                    {
                        fila.Cells["cnTipoVenta"].Value = "Internacional";
                    }
                    else
                    {
                        fila.Cells["cnTipoVenta"].Value = "Nacional";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow fila in DgvProducto.Rows)
                {
                    int i = DgvProducto.SelectedCells[0].RowIndex;
                    if (fila.Cells["cnDescripcion"].Value == DgvProducto.Rows[i].Cells["cnDescripcion"].Value)
                    {
                        string id = fila.Cells["cnId"].Value.ToString();
                        Console.WriteLine(id);
                        using (var client = new HttpClient())
                        {
                            var result = await client.GetAsync(newUri+id);
                            if (result.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Mejor Producto Aceptado");
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