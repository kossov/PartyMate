namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class ClubHiddenImageVoteService : IClubHiddenImageVoteService
    {
        private IRepository<ClubHiddenImageVote> votes;

        public ClubHiddenImageVoteService(IDeletableEntityRepository<ClubHiddenImageVote> votes)
        {
            this.votes = votes;
        }

        public void Add(ClubHiddenImageVote vote)
        {
            this.votes.Add(vote);
            this.votes.SaveChanges();
        }

        public IQueryable<ClubHiddenImageVote> GetAll()
        {
            return this.votes.All();
        }

        public ClubHiddenImageVote GetById(int id)
        {
            return this.votes.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
