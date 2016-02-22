namespace PartyMate.Web.Areas.Api.Models.HiddenImage
{
    using System.ComponentModel.DataAnnotations;

    public class HiddenImageBindingModel
    {
        public int ClubId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}