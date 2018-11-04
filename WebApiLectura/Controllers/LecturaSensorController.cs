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

namespace WebApiLectura.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LecturaSensorController : ApiController
    {
        private BLLecturaSensor BLLectura = new BLLecturaSensor();
        // GET: api/LecturaSensor/1
        public List<LecturaSensor> Get(int id)
        {
            return BLLectura.getLecturaSensor(id);
        }

        

        // POST: api/LecturaSensor
        public HttpResponseMessage Post([FromBody]LecturaSensor value)
        {
            //if(json!= null)
            //{
            //    LecturaSensor value = JsonConvert.DeserializeObject<LecturaSensor>(json);
                if (value != null)
                {
                    BLLectura.AltaLectura(value);
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
            //}
            //else
            //{
            //    return new HttpResponseMessage()
            //    {
            //        Content = new StringContent("400")
            //    };
            //}
            

        }

    }
}
