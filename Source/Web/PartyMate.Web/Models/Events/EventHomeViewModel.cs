namespace PartyMate.Web.Models.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using PartyMate.Data.Models;
    using PartyMate.Web.Infrastructure.Mapping;

    public class EventHomeViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public string ClubName { get; set; }

        public string Title { get; set; }
        
        public DateTime StartsAt { get; set; }

        public string EventOwner { get; set; }

        public string Genre { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(m => m.ClubName, opts => opts.MapFrom(e => e.Club.Name))
                .ForMember(m => m.Genre, opts => opts.MapFrom(e => e.MusicGenre.Genre.ToString()));
        }
    }
}