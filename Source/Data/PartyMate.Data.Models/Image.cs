namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Image : BaseModel<int>
    {
        [Required]
        public byte[] Content { get; set; }
    }
}
