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
        private string url = "http://127.0.0.1:8000/api_carga/carga_old/";
        private string url2 = "http://127.0.0.1:8000/api_subasta/subasta_old/";
        getPostulacion Get = new getPostulacion();
        public Postulacion()
        {
            InitializeComponent();
        }
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string respuesta = await Get.GetHttp4();
                List<Carga> lista = JsonConvert.DeserializeObject<List<Carga>>(respuesta);
                string respuesta2 = await Get.GetHttp();
                List<Subasta> lista2 = JsonConvert.DeserializeObject<List<Subasta>>(respuesta2);
                string respuesta3 = await Get.GetHttp3();
                List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta3);
                DgvCarga.DataSource = lista;

                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvCarga.DataSource];
                currencyManager1.SuspendBinding();
                foreach (DataGridViewRow fila in DgvCarga.Rows)
                {
                    foreach (var fila1 in lista)
                    {
                        if (Convert.ToInt32(fila.Cells["cnEstadoFila"].Value) == 0)
                        {
                            fila.Visible = false;
                            currencyManager1.ResumeBinding();
                            break;
                        }
                    }
                    foreach (var fila1 in lista2)
                    {
                        fila.Cells["cnSubasta"].Value = fila1.monto_subasta;
                        break;
                    }
                    foreach (var fila1 in lista3)
                    {
                        fila.Cells["cnTransportista"].Value = fila1.nombre_usuario;
                        break;
                    }
                    DgvCarga.Rows[fila.Index].Cells["cnBoton"].Value = "Aceptar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try {
                string respuesta2 = await Get.GetHttp();
                List<Subasta> lista2 = JsonConvert.DeserializeObject<List<Subasta>>(respuesta2);
                string respuesta3 = await Get.GetHttp3();
                List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta3);
                DgvSubastas.DataSource = lista2;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvSubastas.DataSource];
                currencyManager1.SuspendBinding();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}