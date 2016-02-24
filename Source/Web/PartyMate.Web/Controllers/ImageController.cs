namespace PartyMate.Web.Controllers
{
    using System.Web.Mvc;
    using PartyMate.Services.Data.Interfaces;
    using System;
    public class ImageController : Controller
    {
        private IImageService images;

        public ImageController(IImageService images)
        {
            this.images = images;
        }

        public ActionResult GetImage(int id)
        {
            var image = this.images.GetById(id);
            if (image == null)
            {
                return null;
            }

            var imageData = image.Content;
            return File(imageData, "image/jpg");
        }
    }
}