namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IClubAnonymousReviewService
    {
        IQueryable<ClubAnonymousReview> GetAll();

        ClubAnonymousReview GetById(int id);

        void Add(ClubAnonymousReview review);
    }
}
