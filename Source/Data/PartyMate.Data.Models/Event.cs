namespace PartyMate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using PartyMate.Common;

    public class Event : BaseModel<int>
    {
        private ICollection<Image> photos;
        private ICollection<EventComment> comments;
        private ICollection<EventLike> likes;

        public Event()
        {
            this.photos = new HashSet<Image>();
            this.comments = new HashSet<EventComment>();
            this.likes = new HashSet<EventLike>();
        }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        [Required]
        [MinLength(ModelConstants.EventTitleMinLength)]
        [MaxLength(ModelConstants.EventTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.EventDescriptionMinLength)]
        [MaxLength(ModelConstants.EventDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime StartsAt { get; set; }

        public DateTime? EndsAt { get; set; }

        [MinLength(ModelConstants.EventMinEntranceFee)]
        public double EntranceFee { get; set; }

        public string Url { get; set; }

        public string EventOwner { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int MusicGenreId { get; set; }

        public virtual MusicGenre MusicGenre { get; set; }

        public virtual ICollection<Image> Photos
        {
            get { return this.photos; }
            set { this.photos = value; }
        }

        public virtual ICollection<EventComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<EventLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
