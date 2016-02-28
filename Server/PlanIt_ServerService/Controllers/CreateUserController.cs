using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Microsoft.Azure.Mobile.Server.Config;

namespace PlanIt_ServerService.Controllers
{
    [MobileAppController]
    public class CreateUserController : ApiController
    {
        public string Post()
        {
            return "Hello World!";
        }
    }
}
