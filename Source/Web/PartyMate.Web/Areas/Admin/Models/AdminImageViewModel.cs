namespace PartyMate.Web.Areas.Admin.Models
{
    using PartyMate.Data.Models;
    using PartyMate.Web.Infrastructure.Mapping;

    public class AdminImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }
    }
}