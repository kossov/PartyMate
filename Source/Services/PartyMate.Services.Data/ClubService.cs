namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class ClubService : IClubService
    {
        private IRepository<Club> clubs;

        public ClubService(IDeletableEntityRepository<Club> clubs)
        {
            this.clubs = clubs;
        }

        public void Add(Club club)
        {
            this.clubs.Add(club);
            this.clubs.SaveChanges();
        }

        public IQueryable<Club> GetAll()
        {
            return this.clubs.All();
        }

        public Club GetById(int id)
        {
            return this.clubs.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
