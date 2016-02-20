namespace PartyMate.Data.Models
{
    using System.Collections.Generic;

    using Common.Models;
    using Enums;

    public class MusicGenre : BaseModel<int>
    {
        private ICollection<Club> clubs;
        private ICollection<Event> events;

        public MusicGenre()
        {
            this.clubs = new HashSet<Club>();
            this.events = new HashSet<Event>();
        }

        public MusicGenreEnum Genre { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        public virtual ICollection<Club> Clubs
        {
            get { return this.clubs; }
            set { this.clubs = value; }
        }
    }
}
