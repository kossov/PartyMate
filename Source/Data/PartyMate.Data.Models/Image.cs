namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using PartyMate.Common;

    public class Image : BaseModel<int>
    {
        [Required]
        [RegularExpression(ModelConstants.ValidatorRegexUrl)]
        public string Path { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
