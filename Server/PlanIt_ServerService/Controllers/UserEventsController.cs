using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlanIt_ServerService.DataObjects;

namespace PlanIt_ServerService.Controllers
{
    public class UserEventsController : ApiController
    {
        // GET: api/UserEvents
        public List<EventDTO> Get()
        {
            List<EventDTO> invited = new List<EventDTO>(); //= context.Events.ToList();
            return invited;
        }
    }
}
