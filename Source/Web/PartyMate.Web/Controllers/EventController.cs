using PartyMate.Data.Common;
using PartyMate.Data.Models;
using PartyMate.Web.Infrastructure.Mapping;
using PartyMate.Web.Models;
using PartyMate.Web.Models.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PartyMate.Web.Controllers
{
    public class EventController : Controller
    {
        private const int ItemsPerPage = 15;
        private const string Country = "Bulgaria";
        private const string ApiKey = "f6d7bef45b6bbb407d";
        private const string EventsApiBaseUrl = "http://api.gigatools.com";
        private const string EventsApiUrl = "http://api.gigatools.com/country.json?countries[]=" + Country + "&api_key=" + ApiKey;

        private IDeletableEntityRepository<Event> events;
        private IDeletableEntityRepository<Club> clubs;
        private IDeletableEntityRepository<Image> images;
        private IDeletableEntityRepository<MusicGenre> genres;

        public EventController(IDeletableEntityRepository<Event> events,
            IDeletableEntityRepository<Club> clubs,
            IDeletableEntityRepository<Image> images,
            IDeletableEntityRepository<MusicGenre> genres)
        {
            this.events = events;
            this.clubs = clubs;
            this.images = images;
            this.genres = genres;
        }

        // GET: Events
        [ActionName("_EventsPartial")]
        //[OutputCache(Duration = 1800)]
        public ActionResult Index(int page)
        {
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

            return this.PartialView(pagableList);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            var model = new EventBindingModel();
            model.Id = id;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Add(int id, EventBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var genreInModel = this.genres.All()
                .Where(g => g.Genre == model.Genre)
                .FirstOrDefault();

            if (genreInModel == null)
            {
                genreInModel = new MusicGenre()
                {
                    Genre = model.Genre
                };

                this.genres.Add(genreInModel);
            }

            Image image = null;

            if (model.Image != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.Image.InputStream.CopyTo(memory);
                    var contentAsArray = memory.GetBuffer();

                    image = new Image
                    {
                        Content = contentAsArray
                    };
                }
            }

            this.images.Add(image);

            var club = this.clubs.GetById(id);

            var evnt = new Event()
            {
                Club = club,
                Title = model.Title,
                Description = model.Description,
                StartsAt = model.StartsAt,
                EventOwner = model.EventOwner,
                EntranceFee = model.EntranceFee,
                MusicGenre = genreInModel,
                Url = model.Url,
                Image = image
            };


            this.events.Add(evnt);
            this.events.SaveChanges();

            this.TempData["Notification"] = "Event added successfully!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}