using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlanIt_ServerService.DataObjects;
using PlanIt_ServerService.Models;
using System.Web.Http.Controllers;

namespace PlanIt_ServerService.Controllers
{
    public class UserEventsController : ApiController
    {
        PlanIt_ServerContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new PlanIt_ServerContext();
        }

        // GET: api/UserEvents
        public List<Event> Get()
        {
            List<Event> invited = context.Events.ToList();

            // TODO: Filter by user

            return invited;
        }
    }
}
