namespace PartyMate.Web.Areas.Api.Models.Club
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Location;
    using PartyMate.Web.Infrastructure.Mapping;

    public class ClubDetailsViewModel : IMapFrom<Data.Models.Club>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ProfilePicUrl { get; set; }

        public string Name { get; set; }

        public int Rating  { get; set; }

        public LocationViewModel Location { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Club, ClubDetailsViewModel>()
                .ForMember(m => m.Rating, opts => opts.MapFrom(c => c.Reviews.Count > 0 ? (int)(Math.Ceiling(c.Reviews.Sum(r => r.Rating) / (double)c.Reviews.Count)) : 0));
        }
    }
}