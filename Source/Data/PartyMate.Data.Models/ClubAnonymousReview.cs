namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using PartyMate.Common;

    public class ClubAnonymousReview : BaseModel<int>
    {
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [MinLength(ModelConstants.ClubReviewContentMinLength)]
        [MaxLength(ModelConstants.ClubReviewContentMaxLength)]
        public string Content { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
