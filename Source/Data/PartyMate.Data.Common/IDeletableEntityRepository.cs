namespace PartyMate.Data.Common
{
    using System.Linq;
    using Models;


    public interface IDeletableEntityRepository<T> : IRepository<T>
        where T : class, IDeletableEntity
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}
