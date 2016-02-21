namespace PartyMate.Web.Areas.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Services.Data.Interfaces;
    using Infrastructure.Mapping;
    using Models.Club;
    using Common;
    using Models.Location;
    using Data.Models;
    using System;
    public class ClubsController : ApiController
    {
        private const string SizeOrPageNegativeErrorMessage = "Size must be > 0 and Page >= 0";
        private const string IdNegativeErrorMessage = "Id must be > 0";

        private IClubService clubs;
        private IClubAnonymousReviewService anonymousReviews;
        private IClubHiddenImageService hiddenImages;
        private IClubHiddenImageVoteService hiddenImagesVotes;

        public ClubsController(
            IClubService clubs,
            IClubAnonymousReviewService anonymousReviews,
            IClubHiddenImageService hiddenImages,
            IClubHiddenImageVoteService hiddenImagesVotes)
        {
            this.clubs = clubs;
            this.anonymousReviews = anonymousReviews;
            this.hiddenImages = hiddenImages;
            this.hiddenImagesVotes = hiddenImagesVotes;
        }

        [HttpGet]
        public IHttpActionResult All(int page = 1, int size = GlobalConstants.DefaultPageSize)
        {
            if (page <= 0 || size < 0)
            {
                return this.BadRequest(SizeOrPageNegativeErrorMessage);
            }

            var result = this.clubs.GetAll()
                .Skip((page - 1) * size)
                .Take(size)
                .To<ClubDetailsViewModel>()
                .ToList();

            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return this.BadRequest(IdNegativeErrorMessage);
            }

            var result = this.clubs.GetAll()
                .Where(c => c.Id == id)
                .To<ClubFullDetailsViewModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult InRange(LocationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (model.Latitude == 0 && model.Longitude == 0)
            {
                return this.BadRequest();
            }

            var clubInRange = this.clubs.GetAll()
                .Where(c => Math.Pow((c.Location.Latitude - model.Latitude), 2) + Math.Pow((c.Location.Longitude - model.Longitude), 2) < Math.Pow(GlobalConstants.ClubInRangeRadius, 2))
                .To<ClubDetailsViewModel>()
                .FirstOrDefault();

            return this.Ok(clubInRange);
        }

        //private int isInRange(Location clubLocation, LocationBindingModel currentLocation)
        //{
        //    var R = 6378.137; // Radius of earth in KM

        //    var dLat = (currentLocation.Latitude - clubLocation.Latitude) * Math.PI / 180;
        //    var dLon = (currentLocation.Longitude - clubLocation.Longitude) * Math.PI / 180;
        //    var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        //    Math.Cos(clubLocation.Latitude * Math.PI / 180) * Math.Cos(currentLocation.Latitude * Math.PI / 180) *
        //    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        //    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        //    var d = (int)(R * c);
        //    return d * 1000; // meters
        //}
    }
}
