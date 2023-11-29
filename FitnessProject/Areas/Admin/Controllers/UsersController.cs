using FitnessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly FitnessWebDbEntities _db;

        public UsersController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/Users/User
        public ActionResult User()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password before saving to the database
                // Example: user.password = YourPasswordHashingFunction(user.password);

                _db.Users.Add(user);
                _db.SaveChanges();

                // Redirect to the User list page after a successful creation
                return RedirectToAction("User");
            }

            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password before saving to the database
                // Example: user.password = YourPasswordHashingFunction(user.password);

                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                // Redirect to the User list page after a successful edit
                return RedirectToAction("User");
            }

            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                _db.Users.Remove(user);
                _db.SaveChanges();

                // Return JSON to confirm successful deletion
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return Json(new { success = false, message = ex.Message });
            }
        }




        // GET: Admin/Users/Search
        public ActionResult Search(string searchString)
        {
            var users = _db.Users
                .Where(u => u.username.Contains(searchString) || u.email.Contains(searchString))
                .ToList();

            return View("User", users);
        }
    }
}
