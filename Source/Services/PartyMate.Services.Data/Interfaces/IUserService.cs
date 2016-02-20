namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        IQueryable<User> GetByUserName(string userName);

        void Add(User user);
    }
}
