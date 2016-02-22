namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Image : BaseModel<int>
    {
        [Required]
        public byte[] Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
