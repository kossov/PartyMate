namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface ILocationService
    {
        IQueryable<Location> GetAll();

        Location GetById(int id);

        void Add(Location location);
    }
}
