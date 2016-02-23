using PartyMate.Data.Models;
using PartyMate.Data.Models.Enums;
using PartyMate.Services.Data.Interfaces;
using PartyMate.Web.Areas.Api.Models.HiddenImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartyMate.Web.Areas.Api.Controllers
{
    public class HiddenController : ApiController
    {
        private IClubAnonymousReviewService anonymousReviews;
        private IClubService clubs;
        private IClubHiddenImageService hiddenImages;
        private IClubHiddenImageVoteService hiddenImagesVotes;

        public HiddenController(
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

        [HttpPost]
        public IHttpActionResult Rate(HiddenImageVoteBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var image = this.hiddenImages.GetById(model.ImageId);
            var vote = new ClubHiddenImageVote()
            {
                Image = image,
                Vote = (VoteEnum)model.Rating
            };

            this.hiddenImagesVotes.Add(vote);
            var rating = (int)Math.Ceiling(image.Votes.Sum(v => (int)v.Vote) / (double)image.Votes.Count);
            return this.Ok(rating);
        }
    }
}
