namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Enums;

    public class ClubHiddenImageVote : BaseModel<int>
    {
        public int ImageId { get; set; }

        public virtual ClubHiddenImage Image { get; set; }

        [Required]
        public VoteEnum Vote { get; set; }
    }
}
