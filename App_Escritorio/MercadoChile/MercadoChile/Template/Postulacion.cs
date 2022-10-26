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
        private string url2 = "http://127.0.0.1:8014/api/subasta_old/";
        getPostulacion Get = new getPostulacion();
        public Postulacion()
        {
            InitializeComponent();
        }
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttp();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            string respuesta2 = await Get.GetHttp2();
            List<Calidad> lista2 = JsonConvert.DeserializeObject<List<Calidad>>(respuesta2);
            string respuesta3 = await Get.GetHttp3();
            List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta3);
            DgvCarga.DataSource = lista;
            this.DgvCarga.Columns[7].Visible = false;
            
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvCarga.DataSource];
            currencyManager1.SuspendBinding();
            foreach (DataGridViewRow fila in DgvCarga.Rows)
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

    }
}