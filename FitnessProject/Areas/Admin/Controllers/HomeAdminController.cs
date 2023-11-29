using FitnessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAdmin() {
            return View();
        
        }
        [HttpPost]
        public ActionResult LoginAdmin(string username, string password)
        {
            FitnessWebDbEntities db = new FitnessWebDbEntities();

            var data = db.Users.Where(s => s.username.Equals(username) && s.password.Equals(password)&&s.role==1);
            if (data.Count() > 0)
            {
                Session["User_id"] = data.FirstOrDefault().id;
                Session["role"] = data.FirstOrDefault().role;
                Session["IsLoggedIn"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}