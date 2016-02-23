namespace PartyMate.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using PartyMate.Common;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class BaseAdminController : Controller
    {
    }
}