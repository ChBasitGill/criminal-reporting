using criminal.reporting.database;
using criminal.reporting.models;
using criminal.reporting.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace criminal.reporting.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Station> repository = null;

        public HomeController()
        {
            this.repository = new Repository<Station>();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}