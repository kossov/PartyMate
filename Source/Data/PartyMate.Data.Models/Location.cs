namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Location : BaseModel<int>
    {
        public int ClubId { get; set; }

        [Required]
        public virtual Club Club { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }
    }
}
