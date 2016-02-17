namespace PartyMate.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Common.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using PartyMate.Common;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MinLength(ModelConstants.UserFirstNameMinLength)]
        [StringLength(ModelConstants.UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.UserLastNameMinLength)]
        [StringLength(ModelConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            //// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //// Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            //// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            //// Add custom user claims here
            return userIdentity;
        }
    }
}
