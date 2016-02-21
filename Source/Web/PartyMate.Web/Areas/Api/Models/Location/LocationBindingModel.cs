namespace PartyMate.Web.Areas.Api.Models.Location
{
    using System.ComponentModel.DataAnnotations;

    public class LocationBindingModel
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}