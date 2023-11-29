using FitnessProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly FitnessWebDbEntities _db;

        public PostController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/Post/Post
        public ActionResult Post()
        {
            List<Post> posts = _db.Posts.ToList();
            return View(posts);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Post");
            }

            return View(post);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int id)
        {
            var post = _db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // POST: Admin/Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Post");
            }

            return View(post);
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(int id)
        {
            var post = _db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            var post = _db.Posts.Find(id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Post");
        }

        // GET: Admin/Post/Search
        public ActionResult Search(string searchString)
        {
            var posts = _db.Posts
                .Where(p => p.title.Contains(searchString) || p.content.Contains(searchString) || p.author.Contains(searchString))
                .ToList();

            return View("Post", posts);
        }
    }
}


