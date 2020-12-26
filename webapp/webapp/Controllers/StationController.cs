using criminal.reporting.models;
using criminal.reporting.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp.Controllers
{
    [Authorize]
    public class StationController : Controller
    {
        private IRepository<Station> repository = null;

        public StationController()
        {
            this.repository = new Repository<Station>();
        }
        // GET: Station
        public ActionResult Index()
        {
            ViewBag.Message = Convert.ToString(TempData["Message"]);
            ViewBag.Success = Convert.ToBoolean(TempData["Success"]);
            return View(repository.GetAll());
        }
        public ActionResult Register()
        { 
            return PartialView("~/Views/Station/Register.cshtml");
        }
        public ActionResult Edit(int id)
        {
            return PartialView("~/Views/Station/Edit.cshtml", repository.GetById(id));
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            TempData["Message"] = "Deleted Successfully";
            TempData["Success"] = true;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(Station station)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(station);
                repository.Save();
                TempData["Message"] = "Created Successfully";
                TempData["Success"] = true;
            }
            else
            {
                TempData["Message"] = "Invalid Data";
                TempData["Success"] = false;
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Station station)
        {
            if (ModelState.IsValid)
            {
                repository.Update(station);
                repository.Save();
                TempData["Message"] = "Updated Successfully";
                TempData["Success"] = true;
            }
            else
            {
                TempData["Message"] = "Invalid Data";
                TempData["Success"] = false;
            }

            return RedirectToAction("Index");
        }
    }
}