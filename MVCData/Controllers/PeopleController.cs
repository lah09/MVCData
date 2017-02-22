using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCData.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        private List<People> actress;

        public PeopleController()
        {
            actress = new List<People>
            {
                new People() {name="Salma Hayek", city="New York City", telephone=12340567 },
                new People() {name="Natalie Portman", city="California", telephone=10234567 },
                new People() {name="Angelina Jolie", city="Chicago", telephone=20134567 },
                new People() {name="Keira Knightley", city="Texas", telephone=10235467 },
                new People() {name="Whoopi Goldberg", city="Oregon", telephone=10234576 },
                new People() {name="Alicia Silverstone", city="Florida", telephone=12345670 },
                new People() {name="Anne Hathaway", city="Michigan", telephone=10234756 },
                new People() {name="Ashley Judd", city="Kentucky", telephone=10256347 },
                new People() {name="Nicole Kidman", city="New Jersey", telephone=23456107 },
                new People() {name="Halle Berry", city="Washington", telephone=10362457 },
                new People() {name="Kim Kardashian", city="Ohio", telephone=10234572 },
            };
        }

        public ActionResult IndexPeople()
        {
            return View(actress);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(People newPeople)
        {

            if (ModelState.IsValid)
            {
                db.AddToPeople(newPeople);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newPeople);
            }
        }
    }
}