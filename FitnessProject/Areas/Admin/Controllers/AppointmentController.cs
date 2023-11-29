using FitnessProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly FitnessWebDbEntities _db;

        public AppointmentController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/Appointment/Appointment
        public ActionResult Appointment()
        {
            List<appointment> appointments = _db.appointments.ToList();
            return View(appointments);
        }

        // GET: Admin/Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _db.appointments.Add(appointment);
                _db.SaveChanges();
                return RedirectToAction("Appointment");
            }

            return View(appointment);
        }

        // GET: Admin/Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            var appointment = _db.appointments.Find(id);

            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // POST: Admin/Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Appointment");
            }

            return View(appointment);
        }

        // GET: Admin/Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            var appointment = _db.appointments.Find(id);

            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // POST: Admin/Appointment/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            var appointment = _db.appointments.Find(id);
            _db.appointments.Remove(appointment);
            _db.SaveChanges();
            return RedirectToAction("Appointment");
        }

        // GET: Admin/Appointment/Search
        public ActionResult Search(string searchString)
        {
            var appointments = _db.appointments
                .Where(a => a.name.Contains(searchString) || a.email.Contains(searchString) || a.phone.Contains(searchString))
                .ToList();

            return View("Appointment", appointments);
        }
    }
}
