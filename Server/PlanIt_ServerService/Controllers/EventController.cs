using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PlanIt_ServerService.DataObjects;
using PlanIt_ServerService.Models;

namespace PlanIt_ServerService.Controllers
{
    public class EventController : TableController<EventDTO>
    {
        PlanIt_ServerContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new PlanIt_ServerContext();

            DomainManager = new EntityDomainManager<EventDTO>(context, Request);
        }

        // GET tables/Event
        public IQueryable<EventDTO> GetAllEvents()
        {
            return Query();
        }

        // GET tables/Event/<UnqiueId>
        public SingleResult<EventDTO> GetEvent(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Event/<UniqueId>
        public Task<EventDTO> PatchEvent(string id, Delta<EventDTO> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Event
        public async Task<IHttpActionResult> PostEvent(EventDTO item)
        {
            EventDTO current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
    }
}