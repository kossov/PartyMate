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
    using Models.AnonymousReview;
    using Models.HiddenImage;
    using System.Collections.Generic;
    using Data.Models.Enums;
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
        public IHttpActionResult All(int page = 1, int size = int.MaxValue) //GlobalConstants.DefaultPageSize)
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
        public IHttpActionResult Review(AnonymousReviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var clubToAddReviewTo = this.clubs.GetById(model.ClubId);
            if (clubToAddReviewTo == null)
            {
                return this.BadRequest();
            }

            var newAnonymousReview = new ClubAnonymousReview()
            {
                 Club = clubToAddReviewTo,
                 Content = model.Content,
                 Rating = model.Rating
            };

            this.anonymousReviews.Add(newAnonymousReview);
            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult HiddenImages(int id)
        {
            var club = this.clubs.GetById(id);
            if (club == null)
            {
                return this.BadRequest();
            }

            var images = new List<HiddenImageViewModel>();
            foreach (var image in club.HiddenImages)
            {
                var hiddenImageModel = new HiddenImageViewModel()
                {
                    Path = image.Path
                };

                images.Add(hiddenImageModel);
            }

            return this.Ok(images);
        }

        // TODO: WORK WITH MANY IMAGES
        [HttpPost]
        public IHttpActionResult HiddenImages(HiddenImageBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var club = this.clubs.GetById(model.ClubId);
            if (club == null)
            {
                return this.BadRequest();
            }

            var newHiddenImage = new ClubHiddenImage()
            {
                Club = club,
                Path = model.Path
            };

            this.hiddenImages.Add(newHiddenImage);

            return this.Ok();
        }

        //[HttpPost]
        //public IHttpActionResult InRange(LocationBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return this.BadRequest();
        //    }

        //    var clubInRange = this.clubs.GetAll()
        //        .Where(c => Math.Pow((c.Location.Latitude - model.Latitude), 2) + Math.Pow((c.Location.Longitude - model.Longitude), 2) < Math.Pow(GlobalConstants.ClubInRangeRadius, 2))
        //        .To<ClubDetailsViewModel>()
        //        .FirstOrDefault();

        //    return this.Ok(clubInRange);
        //}

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
