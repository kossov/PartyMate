namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IEventService
    {
        IQueryable<Event> GetAll();

        Event GetById(int id);

        void Add(Event club);
    }
}
