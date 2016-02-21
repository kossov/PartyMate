namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IClubHiddenImageVoteService
    {
        IQueryable<ClubHiddenImageVote> GetAll();

        ClubHiddenImageVote GetById(int id);

        void Add(ClubHiddenImageVote vote);
    }
}