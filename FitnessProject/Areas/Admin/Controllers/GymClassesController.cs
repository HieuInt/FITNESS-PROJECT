using FitnessProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class GymClassesController : Controller
    {
        private readonly FitnessWebDbEntities _db;

        public GymClassesController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/GymClasses/GymClasses
        public ActionResult GymClasses()
        {
            List<gym_classes> gym_Classes = _db.gym_classes.ToList();
            return View(gym_Classes);
        }

        // GET: Admin/GymClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GymClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gym_classes gymClass)
        {
            if (ModelState.IsValid)
            {
                _db.gym_classes.Add(gymClass);
                _db.SaveChanges();
                return RedirectToAction("GymClasses");
            }

            return View(gymClass);
        }

        // GET: Admin/GymClasses/Edit/5
        public ActionResult Edit(int id)
        {
            var gymClass = _db.gym_classes.Find(id);

            if (gymClass == null)
            {
                return HttpNotFound();
            }

            return View(gymClass);
        }

        // POST: Admin/GymClasses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gym_classes gymClass)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(gymClass).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("GymClasses");
            }

            return View(gymClass);
        }

        // GET: Admin/GymClasses/Delete/5
        public ActionResult Delete(int id)
        {
            var gymClass = _db.gym_classes.Find(id);

            if (gymClass == null)
            {
                return HttpNotFound();
            }

            return View(gymClass);
        }

        // POST: Admin/GymClasses/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            var gymClass = _db.gym_classes.Find(id);
            _db.gym_classes.Remove(gymClass);
            _db.SaveChanges();
            return RedirectToAction("GymClasses");
        }

        // GET: Admin/GymClasses/Search
        public ActionResult Search(string searchString)
        {
            var gymClasses = _db.gym_classes
                .Where(gc => gc.class_name.Contains(searchString) || gc.instructor.Contains(searchString) || gc.schedule.Contains(searchString))
                .ToList();

            return View("GymClasses", gymClasses);
        }
    }
}
