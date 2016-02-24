namespace PartyMate.Web.Models.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public string ClubName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartsAt { get; set; }

        public double EntrenceFee { get; set; }

        public string Url { get; set; }

        public string EventOwner { get; set; }

        public string EventImage { get; set; }

        public string Genre { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(m => m.ClubName, opts => opts.MapFrom(e => e.Club.Name))
                .ForMember(m => m.EventImage, opts => opts.MapFrom(e => e.Image.Content))
                .ForMember(m => m.Genre, opts => opts.MapFrom(e => e.MusicGenre.Genre.ToString()));
        }
    }
}