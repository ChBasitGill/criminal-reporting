using criminal.reporting.database;
using criminal.reporting.models;
using criminal.reporting.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace criminal.reporting.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Station> repository = null;
        private IRepository<CrimeCase> crepository = null;

        public HomeController()
        {
            this.repository = new Repository<Station>();
            this.crepository = new Repository<CrimeCase>();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Chart()
        {
            var clist = crepository.GetAll();
            var list = repository.GetAll();
            var gender = clist.GroupBy(s => s.Gender)
                             .Select(group =>
                         new GenderChart
                         {
                             label = group.Key,
                             y = group.Count()
                         });
            var line = clist.GroupBy(s => s.StationId)
                             .Select(group =>
                         new GenderChart
                         {
                             label = list.FirstOrDefault(x=>x.Id==group.Key).Name,
                             y = group.Count()
                         });
            return Json(new { gender= gender, line= line }, JsonRequestBehavior.AllowGet);
        }
        
    }
}