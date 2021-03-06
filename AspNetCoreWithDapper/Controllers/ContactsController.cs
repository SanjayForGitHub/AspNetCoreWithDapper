using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper.Infrastructure;
using Dapper.Domain;
using Dapper.Domain.Entities;

namespace Dapper.Web.Controllers
{
    
    public class ContactsController : Controller
    {
        private readonly IRepository _repo;
        private readonly EFDbContext _db;
        public ContactsController(EFDbContext db, IRepository repo) {
            _db = db;
            _repo = repo;
        }
        // GET: Contacts
        public ActionResult Index()
        {
            //IEnumerable<Contact> contacts = new List<Contact>() {
            //    new Contact(){Id = 1,FirstName = "Sanjay", LastName="Soni" },
            //    new Contact(){Id = 2,FirstName = "Rajeev", LastName="Soni" }
            //};
            var contacts = _repo.GetAll<Contact>();
            return View(contacts);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}