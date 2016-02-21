namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class LocationService : ILocationService
    {
        private IRepository<Location> locations;

        public LocationService(IDeletableEntityRepository<Location> locations)
        {
            this.locations = locations;
        }

        public void Add(Location location)
        {
            this.locations.Add(location);
            this.locations.SaveChanges();
        }

        public IQueryable<Location> GetAll()
        {
            return this.locations.All();
        }

        public Location GetById(int id)
        {
            return this.locations.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
