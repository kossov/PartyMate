namespace PartyMate.Web.Areas.Admin.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminEventViewModel : IMapFrom<Event>
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}