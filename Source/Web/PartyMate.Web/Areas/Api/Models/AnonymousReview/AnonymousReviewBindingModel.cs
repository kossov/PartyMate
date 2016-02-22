namespace PartyMate.Web.Areas.Api.Models.AnonymousReview
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class AnonymousReviewBindingModel
    {
        [Range(0, long.MaxValue)]
        public int ClubId { get; set; }

        [Required]
        [MinLength(GlobalConstants.AnonymousReviewContentMinLength)]
        [MaxLength(GlobalConstants.AnonymousReviewContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
    }
}