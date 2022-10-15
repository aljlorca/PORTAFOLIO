﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Negocio;
using System.Linq;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using File = System.IO.File;
using System.Windows.Documents;
using MercadoChile.Modelos;

namespace MercadoChile.Template
{

    public partial class Publicacion : Form
    {
        private string url = "http://127.0.0.1:8010/api/producto/?format=json";
        private string url2 = "http://127.0.0.1:8000/api/calidad/";
        private string url3 = "http://127.0.0.1:8016/api/usuario/";
        public Publicacion()
        {
            InitializeComponent();
        }
        public async Task<string> GetHttp()
        {

            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttp2()
        {

            WebRequest oRequest = WebRequest.Create(url2);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public async Task<string> GetHttp3()
        {

            WebRequest oRequest = WebRequest.Create(url3);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        private async void btnListar_Click(object sender, EventArgs e)
        {


            string respuesta = await GetHttp();
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            string respuesta2 = await GetHttp2();
            List<Calidad> lista2 = JsonConvert.DeserializeObject<List<Calidad>>(respuesta2);
            string respuesta3 = await GetHttp3();
            List<Usuarios> lista3 = JsonConvert.DeserializeObject<List<Usuarios>>(respuesta3);
            DgvProducto.DataSource = lista;
            this.DgvProducto.Columns[1].Visible = false;
            this.DgvProducto.Columns[7].Visible = false;
            foreach (DataGridViewRow fila in DgvProducto.Rows)
            {
                
                string urlss = fila.Cells["cnImagen"].Value.ToString();                            
                WebClient wc = new WebClient();               
                byte[] bytes = wc.DownloadData(urlss);
                MemoryStream ms = new MemoryStream(bytes);
                Image img = Image.FromStream(ms);
                DgvProducto.Rows[fila.Index].Cells["cnImagen1"].Value = img;
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

        private void btnSelProd_Click(object sender, EventArgs e)
        {
            txtNomProd.Text = DgvProducto.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = DgvProducto.CurrentRow.Cells[3].Value.ToString();
            txtPrecio.Text = DgvProducto.CurrentRow.Cells[4].Value.ToString();
            txtSaldoProd.Text = DgvProducto.CurrentRow.Cells[7].Value.ToString();
            txtCalidad.Text = DgvProducto.CurrentRow.Cells[8].Value.ToString();
            txtProveedor.Text = DgvProducto.CurrentRow.Cells[9].Value.ToString();
        }
    }
        
    }






    
    
