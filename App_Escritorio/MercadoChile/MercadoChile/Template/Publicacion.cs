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

using Image = System.Drawing.Image;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Data.SqlTypes;
using System.Windows.Controls;
using Datos;

namespace MercadoChile.Template
{
    public partial class Publicacion : Form
    {
        getApi Get = new getApi();
        private string url = "http://127.0.0.1:8000/api_venta/venta_old/";
        public Publicacion()
        {
            InitializeComponent();
        }
        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = await Get.GetHttpPedido();
                List<Pedido> lista = JsonConvert.DeserializeObject<List<Pedido>>(respuesta);
                string respuesta2 = await Get.GetHttpUsuario();
                List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);
                string respuesta3 = await Get.GetHttpVenta();
                List<Venta> lista3 = JsonConvert.DeserializeObject<List<Venta>>(respuesta3);
                DgvProducto.DataSource = lista;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvProducto.DataSource];
                currencyManager1.SuspendBinding();
                foreach (DataGridViewRow fila in DgvProducto.Rows)
                {
                    foreach (var fila1 in lista2)
                    {
                        fila.Cells["cnCliente"].Value = fila1.nombre_usuario;
                        break;
                    }
                    foreach (var fila1 in lista3)
                    {
                        if (fila.Cells["cnId"].Value.ToString() == fila1.id_venta)
                        {
                            fila.Visible = false;
                            currencyManager1.ResumeBinding();
                            break;
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSelProd_Click(object sender, EventArgs e)
        {
            try {
                txtDescrip.Text = DgvProducto.CurrentRow.Cells[1].Value.ToString();
                txtFecha.Text = DgvProducto.CurrentRow.Cells[2].Value.ToString();
                txtCliente.Text = DgvProducto.CurrentRow.Cells[3].Value.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = await Get.GetHttpPedido();
                List<Pedido> lista = JsonConvert.DeserializeObject<List<Pedido>>(respuesta);
                foreach (var list in lista)
                {
                    if (list.descripcion_pedido == txtDescrip.Text)
                    {
                        string id = list.id_pedido.ToString();
                        var client = new HttpClient();
                        Venta post2 = new Venta()
                        {
                            id_venta = id,
                            descripcion_venta = txtDescrip.Text,
                            estado_venta = "licitacion",
                            monto_bruto_venta = 0,
                            iva = "0",
                            monto_neto_venta = 0,
                            fecha_venta = txtFecha.Text,
                            tipo_venta = "1",
                            id_usuario = list.id_usuario.ToString(),
                            cantidad_venta = null,
                            monto_transporte = null,
                            monto_aduanas = null,
                            pago_servicio = null,
                            comision_venta = null
                        };
                        var data = JsonSerializer.Serialize<Venta>(post2);
                        HttpContent content =
                            new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                        var httpResponse = await client.PostAsync(url, content);
                        if (MessageBox.Show("Desea Publicar el Producto " + txtDescrip.Text, "Si o No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (httpResponse.IsSuccessStatusCode)
                            {
                                var result = await httpResponse.Content.ReadAsStringAsync();
                                var postResult = JsonSerializer.Deserialize<Venta>(result);
                                MessageBox.Show("Publicado con exito");
                                this.Hide();
                            }
                        }
                        else
                        {
                            txtDescrip.Text = "";
                            txtFecha.Text = "";
                            txtCliente.Text = "";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtDescrip_Enter(object sender, EventArgs e)
        {
            if (txtDescrip.Text == "Descripcion")
            {
                txtDescrip.Text = "";
                txtDescrip.ForeColor = Color.Black;

            }
        }

        private void txtDescrip_Leave(object sender, EventArgs e)
        {
            if (txtDescrip.Text == "")
            {
                txtDescrip.Text = "Descripcion";
                txtDescrip.ForeColor = Color.DimGray;

            }
        }

        private void txtFecha_Enter(object sender, EventArgs e)
        {
            if (txtFecha.Text == "Fecha")
            {
                txtFecha.Text = "";
                txtFecha.ForeColor = Color.Black;

            }
        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {
            if (txtFecha.Text == "")
            {
                txtFecha.Text = "Fecha";
                txtFecha.ForeColor = Color.DimGray;

            }
        }

    private void txtCliente_Enter(object sender, EventArgs e)
        {
            if (txtCliente.Text == "Cliente")
            {
                txtCliente.Text = "";
                txtCliente.ForeColor = Color.Black;

            }
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                txtCliente.Text = "Cliente";
                txtCliente.ForeColor = Color.DimGray;

            }
        }
    }
}

