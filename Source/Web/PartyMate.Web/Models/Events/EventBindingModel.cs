using PartyMate.Common;
using PartyMate.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyMate.Web.Models.Events
{
    public class EventBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.EventTitleMinLength)]
        [MaxLength(ModelConstants.EventTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.EventDescriptionMinLength)]
        [MaxLength(ModelConstants.EventDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime StartsAt { get; set; }

        [Range(0, double.MaxValue)]
        public double EntranceFee { get; set; }

        [RegularExpression(ModelConstants.ValidatorRegexUrl)]
        public string Url { get; set; }

        [Required]
        public string EventOwner { get; set; }

        [Required]
        public MusicGenreEnum Genre { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}