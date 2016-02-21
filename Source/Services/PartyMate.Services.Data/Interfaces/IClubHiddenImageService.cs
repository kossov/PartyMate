namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IClubHiddenImageService
    {
        IQueryable<ClubHiddenImage> GetAll();

        ClubHiddenImage GetById(int id);

        void Add(ClubHiddenImage image);
    }
}
