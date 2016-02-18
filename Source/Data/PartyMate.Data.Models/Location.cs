namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Location : BaseModel<int>
    {
        public int ClubId { get; set; }

        [Required]
        public virtual Club Club { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Adress { get; set; }
    }
}
