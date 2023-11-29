using FitnessProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        private readonly FitnessWebDbEntities _db;

        public StaffController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/Staff/Staff
        public ActionResult Staff()
        {
            List<staff> staffs = _db.staffs.ToList();
            return View(staffs);
        }

        // GET: Admin/Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(staff staff)
        {
            if (ModelState.IsValid)
            {
                _db.staffs.Add(staff);
                _db.SaveChanges();
                return RedirectToAction("Staff");
            }

            return View(staff);
        }

        // GET: Admin/Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var staff = _db.staffs.Find(id);

            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        // POST: Admin/Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(staff staff)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(staff).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Staff");
            }

            return View(staff);
        }

        // GET: Admin/Staff/Delete/5
        public ActionResult Delete(int id)
        {
            var staff = _db.staffs.Find(id);

            if (staff == null)
            {
                return HttpNotFound();
            }

            return View(staff);
        }

        // POST: Admin/Staff/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            var staff = _db.staffs.Find(id);
            _db.staffs.Remove(staff);
            _db.SaveChanges();
            return RedirectToAction("Staff");
        }

        // GET: Admin/Staff/Search
        public ActionResult Search(string searchString)
        {
            var staffs = _db.staffs
                .Where(s => s.name.Contains(searchString) || s.office.Contains(searchString))
                .ToList();

            return View("Staff", staffs);
        }
    }
}
