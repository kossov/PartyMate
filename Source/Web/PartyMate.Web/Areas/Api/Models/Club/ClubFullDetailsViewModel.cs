namespace PartyMate.Web.Areas.Api.Models.Club
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using AutoMapper;

    using PartyMate.Web.Infrastructure.Mapping;
    using Image;
    using Location;

    public class ClubFullDetailsViewModel : IMapFrom<Data.Models.Club>, IHaveCustomMappings
    {
        public string ProfilePicUrl { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string SiteUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string Email { get; set; }

        public int Capacity { get; set; }

        public int Views { get; set; }

        public LocationViewModel Location { get; set; }

        public IEnumerable<ImageViewModel> photos { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Club, ClubDetailsViewModel>()
                .ForMember(m => m.Rating, opts => opts.MapFrom(c => c.Reviews.Count > 0 ? (int)(Math.Ceiling(c.Reviews.Sum(r => r.Rating) / (double)c.Reviews.Count)) : 0));
        }
    }
}