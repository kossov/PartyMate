namespace PartyMate.Services.Data
{
    using System.Linq;

    using Interfaces;
    using PartyMate.Data.Common;
    using PartyMate.Data.Models;

    public class ImageService : IImageService
    {
        private IRepository<Image> images;

        public ImageService(IDeletableEntityRepository<Image> images)
        {
            this.images = images;
        }

        public void Add(Image image)
        {
            this.images.Add(image);
            this.images.SaveChanges();
        }

        public IQueryable<Image> GetAll()
        {
            return this.images.All();
        }

        public Image GetById(int id)
        {
            return this.images.All().FirstOrDefault(v => v.Id == id);
        }
    }
}
