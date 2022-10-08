using MercadoChile.Modelos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;



namespace MercadoChile
{
    public partial class inicioSesion : Form
    {


        public inicioSesion()
        {
            InitializeComponent();


        }
        /*public class Utilidades
        {
            public static Dictionary<string, List<string>> ExtraerErroresDelinicioSesion(string json)
            {
                var respuesta = new Dictionary<string, List<string>>();
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                var errorsJsonElement = jsonElement.GetProperty("errors");
                foreach(var campoConErrores in errorsJsonElement.EnumerateObject())
                {
                    var campo = campoConErrores.Values;
                    var errores = new List<string>();
                    foreach (var errorKind in campoConErrores.Value.EnumerateObject())
                    {
                        var error = errorKind.GetString();
                        errores.Add(error);
                    }
                    respuesta.Add(campo, errores);
                }

            }
        }*/


        /*private async Task iniciarSesion(object data)
        {
            var url = "http://127.0.0.1:8001/api/administrador/";
            var jsoSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            using (var httpClient = new HttpClient())
            { 
                var response = await httpClient.PostAsJsonAsync(url, data);


                    var cuerpo = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("el id" + cuerpo);
                    
                
            }
            
        }*/
        private async void iniciar_Click(object sender, EventArgs e)
        {

            /*string rut = txtrut_admin.Text;
            string pass = txtcontraseña_admin.Text;
            
            var login = new Login() { rut_administrador = rut, contrasena_administrador = pass };
            var response = iniciarSesion(login);      
 
            Console.WriteLine(response);
            Console.WriteLine(rut);
            Console.WriteLine(pass);*/



            Login log = new Login
            {
                rut_administrador = txtrut_admin.Text,
                contrasena_administrador = txtcontraseña_admin.Text
            };
            Uri RequestUri = new Uri("http://127.0.0.1:8001/api/administrador/?format=json");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
        
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response);
                Console.WriteLine(log);
                MessageBox.Show("datos correcotos");
            }
            else
            {
                Console.WriteLine("hola" + response);
                Console.WriteLine("hola" + contentJson);
                MessageBox.Show("datos incorrectos");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
   
}

