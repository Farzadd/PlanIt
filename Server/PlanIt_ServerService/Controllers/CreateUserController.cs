using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PlanIt_ServerService.DataObjects;
using PlanIt_ServerService.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace PlanIt_ServerService.Controllers
{
    [MobileAppController]
    public class CreateUserController : ApiController
    {
        public string Post(User incomingUser)
        {
            UserController userController = new UserController();
            //User existingUser = userController.GetUser(incomingUser.Id).Queryable.ToList()[0];

            PlanIt_ServerContext context = new PlanIt_ServerContext();
            

            return incomingUser.FacebookName;
        }
    }
}
