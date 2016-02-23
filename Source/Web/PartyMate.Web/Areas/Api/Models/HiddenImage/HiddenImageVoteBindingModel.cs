namespace PartyMate.Web.Areas.Api.Models.HiddenImage
{
    using System.ComponentModel.DataAnnotations;
    
    using Data.Models.Enums;

    public class HiddenImageVoteBindingModel
    {
        [Range(1, int.MaxValue)]
        public int ImageId { get; set; }

        [Required]
        public VoteEnum Rating { get; set; }
    }
}