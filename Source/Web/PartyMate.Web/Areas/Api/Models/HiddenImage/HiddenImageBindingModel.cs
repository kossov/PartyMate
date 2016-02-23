namespace PartyMate.Web.Areas.Api.Models.HiddenImage
{
    using System.ComponentModel.DataAnnotations;

    public class HiddenImageBindingModel
    {
        [Range(1, int.MaxValue)]
        public int ClubId { get; set; }

        public string Path { get; set; }
    }
}