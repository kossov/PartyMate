using PartyMate.Data.Common;
using PartyMate.Data.Models;
using PartyMate.Web.Infrastructure.Mapping;
using PartyMate.Web.Models;
using PartyMate.Web.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PartyMate.Web.Controllers
{
    public class EventsController : Controller
    {
        private const int ItemsPerPage = 15;
        private const string Country = "Bulgaria";
        private const string ApiKey = "f6d7bef45b6bbb407d";
        private const string EventsApiBaseUrl = "http://api.gigatools.com";
        private const string EventsApiUrl = "http://api.gigatools.com/country.json?countries[]=" + Country + "&api_key=" + ApiKey;

        private IRepository<Event> events;

        public EventsController(IDeletableEntityRepository<Event> events)
        {
            this.events = events;
        }

        // GET: Events
        public ActionResult Index(int page = 0)
        {
            // SAVE IN CACHE
            

            var allItemsCount = this.events.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = page * ItemsPerPage;
            var events = this.events.All()
                    .OrderByDescending(x => x.StartsAt)
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .To<EventHomeViewModel>()
                    .ToList();

            var pagableList = new PagableListViewModel<EventHomeViewModel>()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                List = events
            };

            return this.PartialView("~/Views/Event/_EventsPartial.cshtml", pagableList);
        }
    }
}