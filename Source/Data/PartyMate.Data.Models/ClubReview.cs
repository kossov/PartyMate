namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using PartyMate.Common;

    public class ClubReview : BaseModel<int>
    {
        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        [Required]
        [MinLength(ModelConstants.ClubReviewContentMinLength)]
        [MaxLength(ModelConstants.ClubReviewContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
