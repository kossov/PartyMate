namespace PartyMate.Web.Models
{
    using System.Collections.Generic;

    public class PagableListViewModel<T> where T : class
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> List { get; set; }
    }
}