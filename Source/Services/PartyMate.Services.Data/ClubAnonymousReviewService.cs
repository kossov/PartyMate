using System;
namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class ClubAnonymousReviewService : IClubAnonymousReviewService
    {
        private IRepository<ClubAnonymousReview> reviews;

        public ClubAnonymousReviewService(IDeletableEntityRepository<ClubAnonymousReview> reviews)
        {
            this.reviews = reviews;
        }

        public void Add(ClubAnonymousReview review)
        {
            this.reviews.Add(review);
            this.reviews.SaveChanges();
        }

        public IQueryable<ClubAnonymousReview> GetAll()
        {
            return this.reviews.All();
        }

        public ClubAnonymousReview GetById(int id)
        {
            return this.reviews.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
