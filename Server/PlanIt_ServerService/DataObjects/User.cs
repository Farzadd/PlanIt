using Microsoft.Azure.Mobile.Server;

namespace PlanIt_ServerService.DataObjects
{
    public class User : EntityData
    {
        public string FacebookID { get; set; }
        public string FacebookName { get; set; }

        public string AuthToken { get; set; }
    }
}