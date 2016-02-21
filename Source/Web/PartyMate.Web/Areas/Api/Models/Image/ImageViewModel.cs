namespace PartyMate.Web.Areas.Api.Models.Image
{
    using Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Data.Models.Image>
    {
        public string Path { get; set; }
    }
}