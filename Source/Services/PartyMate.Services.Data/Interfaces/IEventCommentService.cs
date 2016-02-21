namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IEventCommentService
    {
        IQueryable<EventComment> GetAll();

        EventComment GetById(int id);

        void Add(EventComment comment);
    }
}
