namespace PartyMate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Common.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PartyMate.Common;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;
        private ICollection<Club> clubs;
        private ICollection<EventLike> eventLikes;

        public User()
        {
            this.images = new HashSet<Image>();
            this.clubs = new HashSet<Club>();
            this.eventLikes = new HashSet<EventLike>();
            this.CreatedOn = DateTime.Now;
        }

        [Required]
        [MinLength(ModelConstants.UserFirstNameMinLength)]
        [StringLength(ModelConstants.UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.UserLastNameMinLength)]
        [StringLength(ModelConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        public int? AvatarId { get; set; }

        [ForeignKey("AvatarId")]
        public virtual Image Avatar { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Club> Clubs
        {
            get { return this.clubs; }
            set { this.clubs = value; }
        }

        public virtual ICollection<EventLike> EventLikes
        {
            get { return this.eventLikes; }
            set { this.eventLikes = value; }
        }

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
