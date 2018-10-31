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
        // GET: api/LecturaSensor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LecturaSensor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LecturaSensor
        public void Post([FromBody]LecturaSensor value)
        {

        }

        // PUT: api/LecturaSensor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LecturaSensor/5
        public void Delete(int id)
        {
        }
    }
}
