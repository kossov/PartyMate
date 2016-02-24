namespace PartyMate.Web.Models.Clubs
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Common;
    using Data.Models.Enums;
    using System.Web;

    public class ClubBindingViewModel
    {
        public HttpPostedFileBase ProfilePic { get; set; }

        [Required]
        [MinLength(ModelConstants.ClubNameMinLength)]
        [MaxLength(ModelConstants.ClubNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ModelConstants.ClubAdressMinLength)]
        [MaxLength(ModelConstants.ClubAdressMaxLength)]
        public string Adress { get; set; }

        [Required]
        [MinLength(ModelConstants.ClubPhoneMinLength)]
        public string Phone { get; set; }

        [Display(Name = "Site")]
        [RegularExpression(ModelConstants.ValidatorRegexUrl)]
        public string SiteUrl { get; set; }

        [Display(Name = "Facebook")]
        [RegularExpression(ModelConstants.ValidatorRegexFacebook)]
        public string FacebookUrl { get; set; }

        [Display(Name = "Twitter")]
        [RegularExpression(ModelConstants.ValidatorRegexTwitter)]
        public string TwitterUrl { get; set; }

        [Required]
        [RegularExpression(ModelConstants.ValidatorRegexEmail)]
        public string Email { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Required]
        public MusicGenreEnum Genre { get; set; }

        public string Location { get; set; }
    }
}