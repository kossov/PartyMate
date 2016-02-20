namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class UserService : IUserService
    {
        private readonly IDbRepository<User> users;

        public UserService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public IQueryable<User> GetByUserName(string userName)
        {
            return this.users.All().Where(u => u.UserName == userName);
        }

        public void Add(User user)
        {
            this.users.Add(user);
            this.users.Save();
        }
    }
}
