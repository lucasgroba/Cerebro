using Newtonsoft.Json;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuladorSensor
{
    public partial class Form1 : Form
    {
        private Thread hiloSender;
        public Form1()
        {
            InitializeComponent();
            InicializaCombos();
            InicializarCampos(false);
            hiloSender = new Thread(EnvioLecturas);

        }

        static async Task<string> Call(LecturaSensor lec)
        {
            

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:56225");
                var content = new StringContent(JsonConvert.SerializeObject(lec), Encoding.UTF8, "application/json");
                var request = await cliente.PostAsync("/api/LecturaSensor", content);
                return await request.Content.ReadAsStringAsync();
            }
        }

        private void InicializaCombos()
        {
            this.Tipo_Sen.Items.Add("G");
            this.Tipo_Sen.Items.Add("M");
            this.Tipo_Sen.Items.Add("S");
            this.Tipo_Sen.Items.Add("C");


            this.AlarmaActiva.Items.Add("A");
            this.AlarmaActiva.Items.Add("I");
            this.AlarmaActiva.SelectedItem = "I";

        }

        private void InicializarCampos(bool visible)
        {
            this.Latitude.Visible = visible;
            this.Longitud.Visible = visible;
            this.Aceleracion.Visible = visible;
            this.Velocidad.Visible = visible;
            this.Presion.Visible = visible;
            this.Temperatura.Visible = visible;
            this.AlarmaActiva.Visible = visible;
            this.NivelCombustible.Visible = visible;
            this.Latitude.Text = "-1";
            this.Longitud.Text = "-1";
            this.Aceleracion.Text = "-1";
            this.Velocidad.Text = "-1";
            this.Presion.Text = "-1";
            this.Temperatura.Text = "-1";
            this.NivelCombustible.Text = "-1";
            
        }

        private void Tipo_Sen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object item = this.Tipo_Sen.SelectedItem;
            switch (item)
            {
                case "G":
                    InicializarCampos(false);
                    this.Latitude.Visible = true;
                    this.Longitud.Visible = true;
                    this.Aceleracion.Visible = true;
                    this.Velocidad.Visible = true;
                    break;
                case "M":
                    InicializarCampos(false);
                    this.Presion.Visible = true;
                    this.Temperatura.Visible = true;
                    break;
                case "S":
                    InicializarCampos(false);
                    this.AlarmaActiva.Visible = true;
                    break;
                case "C":
                    InicializarCampos(false);
                    this.NivelCombustible.Visible = true;
                    break;
            }
        }

        public void EnvioLecturas()
        {
            while (true)
            {
                LecturaSensor lec = new LecturaSensor();
                lec.Latitud = float.Parse(this.Latitude.Text);
                lec.Longitud = float.Parse(this.Longitud.Text);
                lec.Aceleracion = int.Parse(this.Aceleracion.Text);
                lec.Temperatura = int.Parse(this.Temperatura.Text);
                lec.Presion = int.Parse(this.Presion.Text);
                lec.Velocidad = int.Parse(this.Velocidad.Text);
                lec.Nivel_Combustible = int.Parse(this.NivelCombustible.Text);
                lec.SensorRef = int.Parse(this.IdSensor.Text);
                lec.FechaLectura = DateTime.Now;
                if (this.AlarmaActiva.SelectedItem.Equals("A"))
                {
                    lec.Alarma_Activa = true;
                }
                else
                {
                    lec.Alarma_Activa = false;
                }

                Console.WriteLine(Call(lec));
                Thread.Sleep(5000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            hiloSender.Start();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hiloSender.Abort();
        }
    }
}
