using FitnessProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessProject.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        private readonly FitnessWebDbEntities _db;

        public ClientController()
        {
            _db = new FitnessWebDbEntities();
        }

        // GET: Admin/Client/Client
        public ActionResult Client()
        {
            List<Client> clients = _db.Clients.ToList();
            return View(clients);
        }

        // GET: Admin/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
                return RedirectToAction("Client");
            }

            return View(client);
        }

        // GET: Admin/Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _db.Clients.Find(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Admin/Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Client");
            }

            return View(client);
        }

        // GET: Admin/Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _db.Clients.Find(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Admin/Client/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            var client = _db.Clients.Find(id);
            _db.Clients.Remove(client);
            _db.SaveChanges();
            return RedirectToAction("Client");
        }

        // GET: Admin/Client/Search
        public ActionResult Search(string searchString)
        {
            var clients = _db.Clients
                .Where(c => c.Fullname.Contains(searchString) || c.email.Contains(searchString) || c.phone.Contains(searchString))
                .ToList();

            return View("Client", clients);
        }
    }
}
