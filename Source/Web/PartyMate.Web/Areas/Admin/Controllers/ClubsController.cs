namespace PartyMate.Web.Areas.Admin
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using PartyMate.Data.Models;
    using PartyMate.Data.Common;
    using PartyMate.Web.Areas.Admin.Models;
    using PartyMate.Web.Infrastructure.Mapping;

    public class ClubsController : Controller
    {
        private IDeletableEntityRepository<Club> clubs;

        public ClubsController(IDeletableEntityRepository<Club> clubs)
        {
            this.clubs = clubs;
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Clubs_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Club> clubs = this.clubs.All();
            DataSourceResult result = clubs
                .To<AdminClubViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clubs_Update([DataSourceRequest]DataSourceRequest request, AdminClubViewModel model)
        {
            if (ModelState.IsValid)
            {
                var club = this.clubs.GetById(model.Id);
                club.Name = model.Name;
                club.Adress = model.Adress;
                club.Phone = model.Phone;
                club.Email = model.Email;
                club.Phone = model.Phone;
                club.SiteUrl = model.SiteUrl;
                club.FacebookUrl = model.FacebookUrl;
                club.TwitterUrl = model.TwitterUrl;
                club.Capacity = model.Capacity;

                this.clubs.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clubs_Destroy([DataSourceRequest]DataSourceRequest request, AdminClubViewModel model)
        {
            var club = this.clubs.GetById(model.Id);
            this.clubs.Delete(club);
            this.clubs.SaveChanges();

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.clubs.Dispose();
            base.Dispose(disposing);
        }
    }
}
