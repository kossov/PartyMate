using System.Web.Mvc;

namespace PartyMate.Web.Areas.ClubModerator
{
    public class ClubModeratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ClubModerator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ClubModerator_default",
                "ClubModerator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}