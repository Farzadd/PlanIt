using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;

using PlanIt_ServerService.DataObjects;
using PlanIt_ServerService.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace PlanIt_ServerService.Controllers
{
    [MobileAppController]
    public class GetUserEventsController : ApiController
    {
        PlanIt_ServerContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new PlanIt_ServerContext();

        }

        [Route("api/getUserEvents")]
        public List<Event> Post(string x)
        {
            List<Event> invited = new List<Event>();//= context.Events.ToList();
            return invited;
        }
    }
}
