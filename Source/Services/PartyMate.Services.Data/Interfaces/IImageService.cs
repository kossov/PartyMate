namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IImageService
    {
        IQueryable<Image> GetAll();

        Image GetById(int id);

        void Add(Image image);
    }
}
