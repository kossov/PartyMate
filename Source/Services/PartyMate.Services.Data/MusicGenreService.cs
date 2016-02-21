namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class MusicGenreService : IMusicGenreService
    {
        private IRepository<MusicGenre> genres;

        public MusicGenreService(IDeletableEntityRepository<MusicGenre> genres)
        {
            this.genres = genres;
        }

        public void Add(MusicGenre genre)
        {
            this.genres.Add(genre);
            this.genres.SaveChanges();
        }

        public IQueryable<MusicGenre> GetAll()
        {
            return this.genres.All();
        }

        public MusicGenre GetById(int id)
        {
            return this.genres.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
