namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IClubService
    {
        IQueryable<Club> GetAll();

        Club GetById(int id);

        void Add(Club club);
    }
}
