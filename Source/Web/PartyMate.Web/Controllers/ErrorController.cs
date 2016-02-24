namespace PartyMate.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return this.View("Error");
        }

        public ViewResult NotAuthorized()
        {
            this.Response.StatusCode = 403;
            return this.View();
        }

        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }

        public ViewResult ServerError()
        {
            this.Response.StatusCode = 500;
            return this.View();
        }
    }
}