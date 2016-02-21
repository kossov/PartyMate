namespace PartyMate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using PartyMate.Common;

    public class Club : BaseModel<int>
    {
        private ICollection<Image> photos;
        private ICollection<Event> events;
        private ICollection<MusicGenre> musicGenres;
        private ICollection<ClubReview> reviews;
        private ICollection<ClubHiddenImage> hiddenImages;
        private ICollection<ClubAnonymousReview> anonymousReviews;

        public Club()
        {
            this.photos = new HashSet<Image>();
            this.events = new HashSet<Event>();
            this.reviews = new HashSet<ClubReview>();
            this.musicGenres = new HashSet<MusicGenre>();
            this.hiddenImages = new HashSet<ClubHiddenImage>();
            this.anonymousReviews = new HashSet<ClubAnonymousReview>();
        }

        [Required]
        [RegularExpression(ModelConstants.ValidatorRegexUrl)]
        public string ProfilePicUrl { get; set; }

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

        [RegularExpression(ModelConstants.ValidatorRegexUrl)]
        public string SiteUrl { get; set; }

        [RegularExpression(ModelConstants.ValidatorRegexFacebook)]
        public string FacebookUrl { get; set; }

        [RegularExpression(ModelConstants.ValidatorRegexTwitter)]
        public string TwitterUrl { get; set; }

        [Required]
        [RegularExpression(ModelConstants.ValidatorRegexEmail)]
        public string Email { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public int Views { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public string ModeratorId { get; set; }

        public virtual User Moderator { get; set; }

        public virtual ICollection<MusicGenre> MusicGenres
        {
            get { return this.musicGenres; }
            set { this.musicGenres = value; }
        }

        public virtual ICollection<Image> Photos
        {
            get { return this.photos; }
            set { this.photos = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        public virtual ICollection<ClubReview> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<ClubHiddenImage> HiddenImages
        {
            get { return this.hiddenImages; }
            set { this.hiddenImages = value; }
        }

        public virtual ICollection<ClubAnonymousReview> AnonymousReviews
        {
            get { return this.anonymousReviews; }
            set { this.anonymousReviews = value; }
        }
    }
}
