namespace PartyMate.Web.Areas.Api.Models.Location
{
    using Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Data.Models.Location>
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}