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

namespace MercadoChile
{
    public partial class eliminarClientes : Form
    {
        private string url = "http://127.0.0.1:8002/api/cargo/?format=json";
        public eliminarClientes()
        {
            InitializeComponent();
        }
        DBApi dBApi = new DBApi();

    }
}
