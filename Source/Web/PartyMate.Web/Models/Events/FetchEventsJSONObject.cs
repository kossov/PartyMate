using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyMate.Web.Models.Events
{
    public class FetchEventsJSONObject
    {
        public string city { get; set; }
        public string country { get; set; }
        public string eventdate { get; set; }
        public string info { get; set; }
        public string name { get; set; }
        public object showtime { get; set; }
        public string state { get; set; }
        public string url { get; set; }
        public string url_tix { get; set; }
        public string venue { get; set; }
        public string event_owner { get; set; }
        public string follow_url { get; set; }
        public string event_image { get; set; }
    }
}