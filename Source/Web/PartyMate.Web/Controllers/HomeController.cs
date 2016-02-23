using PartyMate.Data.Common;
using PartyMate.Data.Models;
using PartyMate.Web.Infrastructure.Mapping;
using PartyMate.Web.Models;
using PartyMate.Web.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PartyMate.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}