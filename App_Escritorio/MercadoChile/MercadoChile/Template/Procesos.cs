using Datos;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MercadoChile.Template
{
    
    public partial class Procesos : Form
    {

        getProcesos Get = new getProcesos();
        public Procesos()
        {
            InitializeComponent();
            DgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                if (Convert.ToInt32(fila.Cells["cnSaldo"].Value) == 1)
                {
                    fila.Visible = false;
                    currencyManager1.ResumeBinding();
                    break;

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
        }
    }
}
