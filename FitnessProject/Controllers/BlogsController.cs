using FitnessProject.Models;
using FitnessProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FitnessProject.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            FitnessWebDbEntities db = new FitnessWebDbEntities();

            List<Post> posts = db.Posts.ToList();

            var postWithClientFullName = (from post in db.Posts
                                          join client in db.Clients on post.client_id equals client.id
                                          where post.client_id == client.id
                                          select new
                                          {
                                              client.Fullname
                                          }).FirstOrDefault();



            PostViewModel model = new PostViewModel
            {
                Posts = posts,
                FullName = postWithClientFullName?.Fullname,

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Post model)
        {
            FitnessWebDbEntities db = new FitnessWebDbEntities();

            try
            {

                db.Posts.Add(model);
                // Thực hiện các thao tác lưu vào cơ sở dữ liệu ở đây
                db.SaveChanges();
                Session["Post"] = true;
                return RedirectToAction("Index", "Home");

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail()
        {

            FitnessWebDbEntities db = new FitnessWebDbEntities();
            List<Post> posts = db.Posts.ToList();

            PostViewModel model = new PostViewModel
            {
                Posts = posts,

            };
            return View(model);

        }
    }
}