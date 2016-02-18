namespace PartyMate.Data.Models
{
    using PartyMate.Data.Common.Models;

    public class EventDisLike : BaseModel<int>
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
