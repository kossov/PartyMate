namespace PartyMate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Event : BaseModel<int>
    {
        private ICollection<Image> photos;
        private ICollection<EventComment> comments;
        private ICollection<EventLike> likes;
        private ICollection<EventDisLike> dislikes;

        public Event()
        {
            this.photos = new HashSet<Image>();
            this.comments = new HashSet<EventComment>();
            this.likes = new HashSet<EventLike>();
            this.dislikes = new HashSet<EventDisLike>();
        }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        [Required]
        public DateTime StartsAt { get; set; }

        public DateTime? EndsAt { get; set; }

        public double EntranceFee { get; set; }

        public int EventImageId { get; set; }

        public virtual Image EventImage { get; set; }

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

        public virtual ICollection<EventDisLike> DisLikes
        {
            get { return this.dislikes; }
            set { this.dislikes = value; }
        }
    }
}
