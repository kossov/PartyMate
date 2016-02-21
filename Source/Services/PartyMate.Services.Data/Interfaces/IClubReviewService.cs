namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IClubReviewService
    {
        IQueryable<ClubReview> GetAll();

        ClubReview GetById(int id);

        void Add(ClubReview review);
    }
}
