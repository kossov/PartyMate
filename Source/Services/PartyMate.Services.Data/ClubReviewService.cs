namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class ClubReviewService : IClubReviewService
    {
        private IRepository<ClubReview> reviews;

        public ClubReviewService(IDeletableEntityRepository<ClubReview> reviews)
        {
            this.reviews = reviews;
        }

        public void Add(ClubReview review)
        {
            this.reviews.Add(review);
            this.reviews.SaveChanges();
        }

        public IQueryable<ClubReview> GetAll()
        {
            return this.reviews.All();
        }

        public ClubReview GetById(int id)
        {
            return this.reviews.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
