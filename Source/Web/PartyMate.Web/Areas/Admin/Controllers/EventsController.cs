namespace PartyMate.Web.Areas.Admin
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using PartyMate.Data.Models;
    using PartyMate.Services.Data.Interfaces;
    using System.Linq;
    using Infrastructure.Mapping;
    using Models;
    using Data.Common;

    public class EventsController : Controller
    {
        private IEventService service;
        private IDeletableEntityRepository<Event> events;

        public EventsController(IDeletableEntityRepository<Event> events)
        {
            this.events = events;
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Events_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Event> events = this.events.All();
            DataSourceResult result = events
                .To<AdminEventViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Update([DataSourceRequest]DataSourceRequest request, AdminEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var evnt = this.events.GetById(model.Id);

                evnt.Title = model.Title;
                evnt.Url = model.Url;

                this.events.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Destroy([DataSourceRequest]DataSourceRequest request, AdminEventViewModel model)
        {
            var evnt = this.events.GetById(model.Id);

            this.events.Delete(evnt);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.events.Dispose();
            base.Dispose(disposing);
        }
    }
}
