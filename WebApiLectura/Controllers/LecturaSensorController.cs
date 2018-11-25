using BusinessLayer.Controladores;
using Newtonsoft.Json;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebPresentation.Hubs;


namespace WebApiLectura.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LecturaSensorController : ApiController{
        public List<Evento> ListaEventos { get; set; }
        public LecturaSensorController() { }

        private BLLecturaSensor BLLectura = new BLLecturaSensor();
        private BLVehiculo BLvehiculo = new BLVehiculo();
        bool EnvioEvento = false;
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
                if (ListaEventos != null)
                {
                    EventoHub hub = new EventoHub();
                    Vehiculo nuevo = new Vehiculo();
                    nuevo = BLvehiculo.GetVehiculo(ListaEventos.First().VehiculoRef);
                    foreach(Sensor s in nuevo.Lista_Sensores)
                    {
                        if (s.Tipo_Sensor.Equals("G"))
                        {
                            
                            hub.LanzarEvento(ListaEventos, s.GetUltimaLectura().Latitud, s.GetUltimaLectura().Longitud);
                            EnvioEvento = true;
                        }
                    }
                    if (!EnvioEvento)
                    {
                        hub.LanzarEvento(ListaEventos);
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

    }
}
