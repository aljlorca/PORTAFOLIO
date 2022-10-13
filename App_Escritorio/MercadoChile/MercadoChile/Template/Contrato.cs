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
        private string url = "http://127.0.0.1:8002/api/contrato/";
        private string url5 = "http://127.0.0.1:8003/api/empresa/";
        public Contrato()
        {
            InitializeComponent();
        }

        private async void Cargar_Empresa(object sender, EventArgs e)
        {
            string respuesta5 = await GetHttp5();
            List<Empresa> lista5 = JsonConvert.DeserializeObject<List<Empresa>>(respuesta5);
            cmb_TipoEmpresa.DataSource = lista5;
            cmb_TipoEmpresa.DisplayMember = "razon_social_empresa";
            cmb_TipoEmpresa.ValueMember = "id_empresa";

        }
        public async Task<string> GetHttp5()
        {

            WebRequest oRequest = WebRequest.Create(url5);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        private async void Crear_Contrato_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccione un Contrato";
            ofd.Filter = "Archivos permitidos|*.pdf";
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
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
                        frm.Add(new StringContent(txt_Id.Text),"id_contrato");
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

    }
}
