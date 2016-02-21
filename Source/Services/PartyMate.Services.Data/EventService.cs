namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class EventService : IEventService
    {
        private IRepository<Event> events;

        public EventService(IDeletableEntityRepository<Event> events)
        {
            this.events = events;
        }

        public void Add(Event evnt)
        {
            this.events.Add(evnt);
            this.events.SaveChanges();
        }

        public IQueryable<Event> GetAll()
        {
            return this.events.All();
        }

        public Event GetById(int id)
        {
            return this.events.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
