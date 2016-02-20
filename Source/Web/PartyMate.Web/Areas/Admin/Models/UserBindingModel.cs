namespace PartyMate.Web.Areas.Admin.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class UserBindingModel
    {
        [Required]
        [MinLength(ModelConstants.UserFirstNameMinLength)]
        [MaxLength(ModelConstants.UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.UserLastNameMinLength)]
        [MaxLength(ModelConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}