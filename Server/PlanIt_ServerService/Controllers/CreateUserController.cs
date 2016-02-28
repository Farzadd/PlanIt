using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http;

using PlanIt_ServerService.DataObjects;
using PlanIt_ServerService.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace PlanIt_ServerService.Controllers
{
    [MobileAppController]
    public class CreateUserController : ApiController
    {
        PlanIt_ServerContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new PlanIt_ServerContext();

        }

        [Route("api/getFieldAgentDisplayName")]
        public string getFieldAgentDisplayName(User incomingUser)
        {
            User user = context.Users.Find(new[] { incomingUser.Id });

            string ret = "";
            if (user != null)
                ret = user.FacebookName;

            return incomingUser.FacebookName + "-" + ret;
        }
    }
}
