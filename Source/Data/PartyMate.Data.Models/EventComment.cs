namespace PartyMate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using PartyMate.Common;

    public class EventComment : BaseModel<int>
    {
        [Required]
        [MinLength(ModelConstants.EventCommentContentMinLength)]
        [MaxLength(ModelConstants.EventCommentContentMaxLength)]
        public string Content { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
