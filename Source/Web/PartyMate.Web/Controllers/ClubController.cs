namespace PartyMate.Web.Controllers
{
    using System.Web.Mvc;
    using Models.Clubs;
    using Data.Models;
    using System.IO;
    using Data.Common;
    using System.Linq;
    using Services.Data.Interfaces;
    public class ClubController : Controller
    {
        private IUserService users;
        private IMusicGenreService genres;
        private IImageService images;
        private IClubService clubs;

        public ClubController(
            IUserService users,
            IMusicGenreService genres,
            IImageService images,
            IClubService clubs)
        {
            this.users = users;
            this.genres = genres;
            this.images = images;
            this.clubs = clubs;
        }

        // GET: Club
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View(new ClubBindingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ClubBindingViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.users.GetAll()
                .Where(u => u.UserName == this.User.Identity.Name)
                .FirstOrDefault();

            Image image = null;

            if (model.ProfilePic != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.ProfilePic.InputStream.CopyTo(memory);
                    var contentAsArray = memory.GetBuffer();

                    image = new Image
                    {
                        Content = contentAsArray
                    };
                }
            }

            this.images.Add(image);

            var genreInModel = this.genres.GetAll()
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

            var clubToAdd = new Club()
            {
                Moderator = user,
                Name = model.Name,
                Adress = model.Adress,
                Phone = model.Phone,
                SiteUrl = model.SiteUrl,
                FacebookUrl = model.FacebookUrl,
                TwitterUrl = model.TwitterUrl,
                Email = model.Email,
                Capacity = model.Capacity,
                MusicGenre = genreInModel,
                ProfilePic = image
            };

            this.clubs.Add(clubToAdd);

            this.TempData["Notification"] = "Club created successfully!";
            return this.RedirectToAction("Index", "Home"); // change later to browse action
        }

        public ActionResult Browse()
        {
            return View();
        }
    }
}