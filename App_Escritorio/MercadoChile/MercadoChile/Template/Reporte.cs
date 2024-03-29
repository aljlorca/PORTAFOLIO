﻿using MercadoChile.Modelos;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace MercadoChile.Template
{
    public partial class Reporte : Form
    {
        getApi Get = new getApi();
        public Reporte()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            string paginahtml_texto = Properties.Resources.Plantilla.ToString();

            string filas = string.Empty;
            decimal total = 0;

            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (DataGridViewRow row in DgvReporte.Rows) 
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["cnID"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["cnDescripcion"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["fecha_venta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["cnCliente"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["cnMontoTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
                total += decimal.Parse(row.Cells["cnMontoTotal"].Value.ToString());

            }

            paginahtml_texto = paginahtml_texto.Replace("@FECHA", fecha);
            paginahtml_texto = paginahtml_texto.Replace("@FILAS", filas);
            paginahtml_texto = paginahtml_texto.Replace("@TOTAL", total.ToString());

            if (guardar.ShowDialog() == DialogResult.OK) 
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create)) 
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.unknown, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(80, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 40);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(paginahtml_texto)) 
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    
                    }

                    pdfDoc.Close();

                    stream.Close();
                }
            
            }
        }

        private async void Reporte_Load(object sender, EventArgs e)
        {
            string respuesta = await Get.GetHttpVenta();
            List<Venta> lista1 = JsonConvert.DeserializeObject<List<Venta>>(respuesta);
            DgvReporte.DataSource = lista1;

            string respuesta2 = await Get.GetHttpUsuario();
            List<Usuarios> lista2 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta2);

            foreach (DataGridViewRow fila in DgvReporte.Rows) 
            {
                foreach (var list in lista2) 
                {
                    if (Convert.ToString(fila.Cells["cnCliente"].Value) == list.id_usuario) 
                    {
                        fila.Cells["cnCliente"].Value = list.nombre_usuario;
                    }
                }
            }
        }
    }
}
