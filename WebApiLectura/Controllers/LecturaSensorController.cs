using BusinessLayer.Controladores;
using Newtonsoft.Json;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using SHARE.DTOs;
using WebPresentation.Hubs;


namespace WebApiLectura.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LecturaSensorController : ApiController{
        public List<Evento> ListaEventos { get; set; }
        public LecturaSensorController() { }

        private BLLecturaSensor BLLectura = new BLLecturaSensor();
        private BLVehiculo BLvehiculo = new BLVehiculo();
        private BLSensor BLSensor = new BLSensor();

        bool EnvioEventoCoord = false;
        // GET: api/LecturaSensor/1
        public List<LecturaSensor> Get(int id)
        {
            return BLLectura.getLecturaSensor(id);
        }


        // POST: api/LecturaSensor
        public HttpResponseMessage Post([FromBody]LecturaSensor value)
        {
              
            if (value != null){
                ListaEventos = BLLectura.AltaLectura(value);
                if (BLLectura.ActualizoLectura(value))
                {
                    DTOLecturaHub lec = new DTOLecturaHub();
                    lec.Lectura = value;
                    lec.vehiculoRef =BLvehiculo.GetVehiculo(BLSensor.GetSensor(value.SensorRef).VehiculoRef).Id;
                    Task<String> responselec = CallLectura(lec);
                }
                if (!ListaEventos.Count.Equals(0))
                {
                    Vehiculo nuevo = new Vehiculo();
                    nuevo = BLvehiculo.GetVehiculo(ListaEventos.First().VehiculoRef);
                    foreach(Sensor s in nuevo.Lista_Sensores)
                    {
                        if (s.Tipo_Sensor.Equals("G"))
                        {
                            
                            Task<String> response = Call(ListaEventos);
                            EnvioEventoCoord = true;
                        }
                    }
                    if (!EnvioEventoCoord)
                    {
                        Task<String> response = Call(ListaEventos);
                    }
                    
                        
                    
                        
                }

                return new HttpResponseMessage()
                {
                    Content = new StringContent("200")
                };
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("500")
                };
            }
          
            

        }

        static async Task<string> Call(List<Evento> ListaEventos)
        {
            
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("http://localhost:58143/");
                    var content = new StringContent(JsonConvert.SerializeObject(ListaEventos), Encoding.UTF8, "application/json");
                    var request = await cliente.PostAsync("EventosHub/Create", content);
                    return await request.Content.ReadAsStringAsync();
                }

            
        }


        static async Task<string> CallLectura(DTOLecturaHub lec)
        {

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:58143/");
                var content = new StringContent(JsonConvert.SerializeObject(lec), Encoding.UTF8, "application/json");
                var request = await cliente.PostAsync("ActualizacionLocationHub/Create", content);
                return await request.Content.ReadAsStringAsync();
            }


        }


    }
}
