using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlanIt_ServerService.Controllers
{
    public class GetEventsController : ApiController
    {
        // GET: api/GetEvents
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetEvents/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GetEvents
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetEvents/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetEvents/5
        public void Delete(int id)
        {
        }
    }
}
