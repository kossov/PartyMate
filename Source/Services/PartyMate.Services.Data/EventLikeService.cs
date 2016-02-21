namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class EventLikeService : IEventLikeService
    {
        private IRepository<EventLike> likes;

        public EventLikeService(IDeletableEntityRepository<EventLike> likes)
        {
            this.likes = likes;
        }

        public void Add(EventLike like)
        {
            this.likes.Add(like);
            this.likes.SaveChanges();
        }

        public IQueryable<EventLike> GetAll()
        {
            return this.likes.All();
        }

        public EventLike GetById(int id)
        {
            return this.likes.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
