namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IEventLikeService
    {
        IQueryable<EventLike> GetAll();

        EventLike GetById(int id);

        void Add(EventLike like);
    }
}
