using BusinessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiLectura.Controllers
{
    public class LecturaSensorController : ApiController
    {
        private BLLecturaSensor BLLectura = new BLLecturaSensor();
        // GET: api/LecturaSensor/1
        public List<LecturaSensor> Get(int id)
        {
            return BLLectura.getLecturaSensor(id);
        }

        

        // POST: api/LecturaSensor
        public void Post([FromBody]LecturaSensor value)
        {
            BLLectura.AltaLectura(value);

        }

    }
}
