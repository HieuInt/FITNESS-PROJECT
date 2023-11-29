using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FitnessProject.Models;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private FitnessWebDbEntities db = new FitnessWebDbEntities();

        // GET: Admin/Category
        public ActionResult Category()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,category_name,describe")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Category");
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,category_name,describe")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Category");
            }

            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = db.Categories.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var cat = db.Categories.Find(id);
                if (cat == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                db.Categories.Remove(cat);
                db.SaveChanges();

                // Return JSON to confirm successful deletion
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Admin/Category/Search
        public ActionResult Search(string searchString)
        {
            var categories = db.Categories
                .Where(c => c.category_name.Contains(searchString) || c.describe.Contains(searchString))
                .ToList();

            return View("Category", categories);
        }
    }
}
