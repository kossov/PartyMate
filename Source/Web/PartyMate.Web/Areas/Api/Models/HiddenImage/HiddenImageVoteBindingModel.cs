namespace PartyMate.Web.Areas.Api.Models.HiddenImage
{
    using System.ComponentModel.DataAnnotations;

    public class HiddenImageVoteBindingModel
    {
        [Range(1, int.MaxValue)]
        public int ImageId { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }
    }
}