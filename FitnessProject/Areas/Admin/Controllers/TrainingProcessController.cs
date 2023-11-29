using FitnessProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class TrainingProcessController : Controller
    {
        private readonly    FitnessWebDbEntities _db;

        public TrainingProcessController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/TrainingProcess/TrainingProcess
        public ActionResult TrainingProcess()
        {
            List<training_process> trainingProcesses = _db.training_process.ToList();
            return View(trainingProcesses);
        }

        // GET: Admin/TrainingProcess/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TrainingProcess/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(training_process trainingProcess)
        {
            if (ModelState.IsValid)
            {
                _db.training_process.Add(trainingProcess);
                _db.SaveChanges();
                return RedirectToAction("TrainingProcess");
            }

            return View(trainingProcess);
        }

        // GET: Admin/TrainingProcess/Edit/5
        public ActionResult Edit(int id)
        {
            var trainingProcess = _db.training_process.Find(id);

            if (trainingProcess == null)
            {
                return HttpNotFound();
            }

            return View(trainingProcess);
        }

        // POST: Admin/TrainingProcess/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(training_process trainingProcess)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(trainingProcess).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("TrainingProcess");
            }

            return View(trainingProcess);
        }

        // GET: Admin/TrainingProcess/Delete/5
        public ActionResult Delete(int id)
        {
            var trainingProcess = _db.training_process.Find(id);

            if (trainingProcess == null)
            {
                return HttpNotFound();
            }

            return View(trainingProcess);
        }

        // POST: Admin/TrainingProcess/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            var trainingProcess = _db.training_process.Find(id);
            _db.training_process.Remove(trainingProcess);
            _db.SaveChanges();
            return RedirectToAction("TrainingProcess");
        }

        // GET: Admin/TrainingProcess/Search
        public ActionResult Search(string searchString)
        {
            var trainingProcesses = _db.training_process
                .Where(tp => tp.category.Contains(searchString) || tp.coach.Contains(searchString))
                .ToList();

            return View("TrainingProcess", trainingProcesses);
        }
    }
}
