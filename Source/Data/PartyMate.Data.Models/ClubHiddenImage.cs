namespace PartyMate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class ClubHiddenImage : BaseModel<int>
    {
        private ICollection<ClubHiddenImageVote> votes;

        public ClubHiddenImage()
        {
            this.votes = new HashSet<ClubHiddenImageVote>();
        }

        [Required]
        public string Path { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        public virtual ICollection<ClubHiddenImageVote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
