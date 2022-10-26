﻿using Datos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MercadoChile.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoChile.Template
{

    public partial class Contrato : Form
    {
        private string url = "http://127.0.0.1:8004/api/contrato/";
        getContrato Get = new getContrato();
        public Contrato()
        {
            InitializeComponent();
        }

        private async void Cargar_Empresa(object sender, EventArgs e)
        {
            string respuesta2 = await Get.GetHttp2();
            List<Empresas> lista2 = JsonConvert.DeserializeObject<List<Empresas>>(respuesta2);
            cmb_TipoEmpresa.DataSource = lista2;
            cmb_TipoEmpresa.DisplayMember = "razon_social_empresa";
            cmb_TipoEmpresa.ValueMember = "id_empresa";

        }
       
        private async void Crear_Contrato_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccione un Contrato";
            ofd.Filter = "Archivos permitidos|*.pdf";
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string id = cmb_TipoEmpresa.Text + "_" + dateTimePicker1.Value.ToString();
            Console.WriteLine(id);
            Console.WriteLine(theDate);
            
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                string mensajeRespuesta = "";
                int tipoRespuesta = 2;
                string nombreCompletoArchivo = ofd.FileName;
                byte[] arrContenido = null;
                using (FileStream fs = new FileStream(nombreCompletoArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    arrContenido = new byte[fs.Length];
                    await fs.ReadAsync(arrContenido, 0, arrContenido.Length);
                }
                if (arrContenido == null) mensajeRespuesta = "Ocurrió un inconveniente al obtener el contenido del archivo " + nombreCompletoArchivo;
                else
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string nombreArchivo = Path.GetFileName(nombreCompletoArchivo);
                        MultipartFormDataContent frm = new MultipartFormDataContent();
                        frm.Add(new StringContent(id),"id_contrato");
                        frm.Add(new ByteArrayContent(arrContenido), "documento_contrato", nombreArchivo);
                        frm.Add(new StringContent(theDate), "fecha_contrato");
                        frm.Add(new StringContent(txt_TipoContrato.Text), "tipo_contrato");
                        frm.Add(new StringContent("1"), "estado_fila");
                        frm.Add(new StringContent(cmb_TipoEmpresa.SelectedValue.ToString()), "id_empresa");
                        using (HttpResponseMessage resultadoConsulta = await client.PostAsync(url, frm))
                        {
                            mensajeRespuesta = await resultadoConsulta.Content.ReadAsStringAsync();
                            if (resultadoConsulta.IsSuccessStatusCode)
                                tipoRespuesta = 1;
                            else
                                tipoRespuesta = 2;
                        }
                    }
                }

                MessageBoxIcon iconoMensaje;
                if (tipoRespuesta == 1)
                    iconoMensaje = MessageBoxIcon.Information;
                else if (tipoRespuesta == 2)
                    iconoMensaje = MessageBoxIcon.Warning;
                else
                    iconoMensaje = MessageBoxIcon.Error;
                MessageBox.Show(mensajeRespuesta, "Carga de archivos", MessageBoxButtons.OK, iconoMensaje);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\MiniBalto\Desktop\duoc\Contrato MercadoChile.pdf", FileMode.Create);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            pw.PageEvent = new HeaderFooter();

            doc.SetMargins(85f, 85f, 85f, 85f);
            doc.Open();

            doc.AddAuthor("WireBox");
            doc.AddTitle("PDF Generad");
            iTextSharp.text.Image firma = iTextSharp.text.Image.GetInstance(@"C:\Users\MiniBalto\Desktop\duoc\fima.jpg");

            firma.ScaleAbsoluteWidth(100);
            firma.ScaleAbsoluteHeight(100);



            PdfPTable table = new PdfPTable(1);

            PdfPCell _cell = new PdfPCell();

            _cell = new PdfPCell(new Paragraph("Contrato Mercado Chile"));
            _cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(_cell);
            doc.Add(table);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("En Santiago a 14/10/2022 Entre Mercado Chile Rut 99.999.999-9 Represantada  por Homero Simsomp en su calidad de gerente general " +
                "Cedula de identidad N° 22.222.222-2 ambos domiciliados en avenida siempre viva N°666 comuna de Sprinfield ciudad de Santiago que en adelante se denomina el mandante" +
                " y don " + txtNombreCliente.Text + " de nacionalidad "+txtNacionalidad.Text+" cedula de identidad " + txtRut.Text + " domiciliado en " + txtDireccionCliente.Text + 
                " han acordado el contrato de prestacion de servicios que consta de las siguiente clausulas que a continuación se exponen")
            { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("PRIMERO. En virtud del presente contrato de prestacion de servicios, el mandatario se compromete a ejecutar el siguiente cargo: "+ txtCargo.Text+" de productos" +
                " de la empresa Mercado Chile ")
            { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Las partes dejan expresa constancia que en el desempeño del encargo señalado en el parrafo precedente, el mandatario se desempeñara como trabjador" +
                " independiente, no existiendo vinculo de subordinación o dependencia con el mandante. Por lo tanto, el Encargo o servicio que se le a encomendado lo afectuara" +
                " en el horario y condiciones convenidas")
            { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("SEGUNDO. Toda colaboracion que en el mandatario solicite a otras personas, a cualquier titulo sera de su exclusiva responsabilidad, no generandose" +
                "obligacion alguna para el mandate en relacion con dichas personas")
            { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("TERCERO. Las partes podrán desahuciar el presente contrato dando aviso anticipado de 30 dias, que deberá constar por escrito, que en este" +
                " caso se da por enterada que es con fecha 15/10/2022")
            { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Asimismo, el contrato terminara por las causales de extincion del mandato prescritas por el articulo 2.163 del codigo civil.") { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("CUARTO. Para las custiones a que dé lugar este contrato, las partes fijan domicilio en la ciudad, y se someten a la jurisdicción de sus Tribunales") { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("QUINTO. El Presente contrato se suscribe en duplicado, quedando una copia en poder de cada parte.") { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(firma);
            doc.Add(new Paragraph("FIRMA MANDANTE                                           FIRMA DEL MANDATARIO"));
            doc.Add(new Paragraph("RUT: 99.999.999-9                                             RUT: "+ txtRut.Text ));

            doc.Close();


            MessageBox.Show("Documento generado con Exito");


        }
        class HeaderFooter : PdfPageEventHelper 
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfPTable tbHeader = new PdfPTable(3);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbHeader.DefaultCell.Border = 0;

                tbHeader.AddCell(new Paragraph());

                PdfPCell _cell = new PdfPCell(new Paragraph("Contrato Mercado Chile"));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;

                tbHeader.AddCell(_cell);
                tbHeader.AddCell(new Paragraph());


                PdfPTable tbFooter = new PdfPTable(3);
                tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbFooter.DefaultCell.Border = 0;

                tbFooter.AddCell(new Paragraph());

                _cell = new PdfPCell(new Paragraph("Firma Cliente"));
                _cell.HorizontalAlignment = Element.ALIGN_LEFT;

                tbFooter.AddCell(_cell);

                _cell = new PdfPCell(new Paragraph("firma MercadoChile"));
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;


                tbFooter.AddCell(new Paragraph());


            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txt_Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TipoContrato_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
