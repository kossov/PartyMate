namespace PartyMate.Data.Models
{
    using Common.Models;

    public class EventLike : BaseModel<int>
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
