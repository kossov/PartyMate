namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Image : BaseModel<int>
    {
        [Required]
        public string Path { get; set; }
    }
}
