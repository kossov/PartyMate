namespace PartyMate.Data.Models
{
    using System.Collections.Generic;

    using Common.Models;

    public class Club : BaseModel<int>
    {
        private ICollection<Image> photos;
        private ICollection<Event> events;
        private ICollection<ClubReview> reviews;

        public Club()
        {
            this.photos = new HashSet<Image>();
            this.events = new HashSet<Event>();
            this.reviews = new HashSet<ClubReview>();
        }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public string SiteUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string Email { get; set; }

        public int Capacity { get; set; }

        public int Views { get; set; }

        public string ModeratorId { get; set; }

        public virtual User Moderator { get; set; }

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
    }
}
