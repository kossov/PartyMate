namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class EventCommentService : IEventCommentService
    {
        private IRepository<EventComment> comments;

        public EventCommentService(IDeletableEntityRepository<EventComment> comments)
        {
            this.comments = comments;
        }

        public void Add(EventComment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public IQueryable<EventComment> GetAll()
        {
            return this.comments.All();
        }

        public EventComment GetById(int id)
        {
            return this.comments.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
