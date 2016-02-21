namespace PartyMate.Services.Data.Interfaces
{
    using System.Linq;

    using PartyMate.Data.Models;

    public interface IMusicGenreService
    {
        IQueryable<MusicGenre> GetAll();

        MusicGenre GetById(int id);

        void Add(MusicGenre location);
    }
}
