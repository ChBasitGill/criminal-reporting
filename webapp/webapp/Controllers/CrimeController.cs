using criminal.reporting.models;
using criminal.reporting.repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp.Controllers
{
    [Authorize]
    public class CrimeController : Controller
    {
        private IRepository<CrimeCase> repository = null;
        private IRepository<Station> srepository = null;

        public CrimeController()
        {
            this.repository = new Repository<CrimeCase>();
            this.srepository = new Repository<Station>();
        }
        // GET: Crimes
        public ActionResult Index()
        {
            ViewBag.Message = Convert.ToString(TempData["Message"]);
            ViewBag.Success = Convert.ToBoolean(TempData["Success"]);
            var list = srepository.GetAll().ToList();
            var crimes = repository.GetAll().ToList();
            foreach (var item in crimes)
            {
                item.Station = list.Where(x => x.Id == item.StationId)?.FirstOrDefault();
            }
            ViewBag.ShowCreate= (list.ToList().Count >0) ?true:false;

            return View(crimes);
        }
        public ActionResult Register()
        {
            var model = new CrimeCaseDto();
            ViewBag.Stations = new SelectList(srepository.GetAll(), "Id", "Name", model.StationId);
            model.Date = DateTime.Now;
            model.Time = DateTime.Now;
            return PartialView(model);
        }
        public ActionResult Edit(int id)
        {
            CrimeCase crime = repository.GetById(id);
            var data = new CrimeCaseDto()
            {
                Gender = crime.Gender,
                Date = crime.DateOfCrime,
                Time= crime.DateOfCrime,
                Address = crime.Address,
                CaseImages = crime.CaseImages,
                Age = crime.Age,
                Contact = crime.Contact,
                CrimeInfo = crime.CrimeInfo,
                Name = crime.Name,
                Id = crime.Id,
                StationId = crime.StationId,
                CNIC = crime.CNIC,
            };
            ViewBag.Stations = new SelectList(srepository.GetAll(), "Id", "Name", crime.StationId);
            return PartialView("~/Views/Crime/Edit.cshtml", data);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrimeCaseDto crime)
        {
            List<string> images = new List<string>();
            if (ModelState.IsValid)
            {
                foreach (var item in crime.ImageFile)
                {
                    string path = Path.Combine(Server.MapPath("~/Upload"),
                                              Path.GetFileName(item.FileName));
                    item.SaveAs(path);
                    images.Add("/Upload/"+item.FileName);
                }

                var data = new CrimeCase()
                {
                    Gender = crime.Gender,
                    DateOfCrime = crime.Date.Date.Add(crime.Time.TimeOfDay),
                    Address = crime.Address,
                    CaseImages = string.Join(",", images.ToArray()),
                    Age = crime.Age,
                    Contact = crime.Contact,
                    CrimeInfo = crime.CrimeInfo,
                    Name = crime.Name,
                    Id = crime.Id,
                    StationId = crime.StationId,
                    CNIC = crime.CNIC,
                };
                repository.Insert(data);
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
        public ActionResult Edit(CrimeCaseDto crime)
        {
            List<string> images = new List<string>();
            if (ModelState.IsValid)
            {   
                foreach (var item in crime.ImageFile)
                {
                    if (item != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Upload"),
                                                                      Path.GetFileName(item.FileName));
                        item.SaveAs(path);
                        images.Add("/Upload/" + item.FileName);
                    }
                }
                var data = new CrimeCase()
                {
                    Gender = crime.Gender,
                    DateOfCrime = crime.Date.Date.Add(crime.Time.TimeOfDay),
                    Address = crime.Address,
                    CaseImages = string.Join(",", images.ToArray()),
                    Age = crime.Age,
                    Contact = crime.Contact,
                    CrimeInfo = crime.CrimeInfo,
                    Name = crime.Name,
                    Id = crime.Id,
                    StationId = crime.StationId,
                    CNIC = crime.CNIC,
                };
                repository.Update(data);
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