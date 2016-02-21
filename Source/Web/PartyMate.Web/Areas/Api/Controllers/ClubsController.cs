namespace PartyMate.Web.Areas.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Services.Data.Interfaces;
    using Infrastructure.Mapping;
    using Models.Club;
    using Common;

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

        // POST: api/Clubs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clubs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clubs/5
        public void Delete(int id)
        {
        }
    }
}
