namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class ClubHiddenImageService : IClubHiddenImageService
    {
        private readonly IDeletableEntityRepository<ClubHiddenImage> images;

        public ClubHiddenImageService(IDeletableEntityRepository<ClubHiddenImage> images)
        {
            this.images = images;
        }

        public void Add(ClubHiddenImage image)
        {
            this.images.Add(image);
            this.images.SaveChanges();
        }

        public IQueryable<ClubHiddenImage> GetAll()
        {
            return this.images.All();
        }

        public ClubHiddenImage GetById(int id)
        {
            return this.images.All().FirstOrDefault(i => i.Id == id);
        }
    }
}
