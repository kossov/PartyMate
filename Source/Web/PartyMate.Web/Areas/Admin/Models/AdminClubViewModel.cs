namespace PartyMate.Web.Areas.Admin.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using PartyMate.Data.Models;
    using PartyMate.Web.Infrastructure.Mapping;

    public class AdminClubViewModel : IMapFrom<Club>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte[] ProfilePic { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string SiteUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string Email { get; set; }

        public int Capacity { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Club, AdminClubViewModel>()
                .ForMember(m => m.ProfilePic, opts => opts.MapFrom(c => c.ProfilePic.Content));
        }
    }
}