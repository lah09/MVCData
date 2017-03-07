using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MVCData.Controllers
{
    public class PeopleController : Controller      //inheritance
    {
        // GET: People
        static IList<People> actress = new List<People>  //static variable exists in memory for all the objects of that class
                                                         //IList = more control over a collection: Add, Delete, etc
{
    new People() {PersonId=1, Name="Salma Hayek", City="New York City", Telephone=12340567 },       //new List's object
    new People() {PersonId=2, Name="Natalie Portman", City="California", Telephone=10234567 },
    new People() {PersonId=3, Name="Angelina Jolie", City="Chicago", Telephone=20134567 },
    new People() {PersonId=4, Name="Keira Knightley", City="Texas", Telephone=10235467 },
    new People() {PersonId=5, Name="Whoopi Goldberg", City="Oregon", Telephone=10234576 },
    new People() {PersonId=6, Name="Alicia Silverstone", City="Florida", Telephone=12345670 },
    new People() {PersonId=7, Name="Anne Hathaway", City="Michigan", Telephone=10234756 },
    new People() {PersonId=8, Name="Ashley Judd", City="Kentucky", Telephone=10256347 },
    new People() {PersonId=9, Name="Nicole Kidman", City="New Jersey", Telephone=23456107 },
    new People() {PersonId=10, Name="Halle Berry", City="Washington", Telephone=10362457 },
    new People() {PersonId=11, Name="Kim Kardashian", City="Ohio", Telephone=10234572 },
};

        [HttpGet]       //displays a form for user entry
        public ActionResult IndexPeople()
        {
            return View(actress.ToList());      //displays all the List of name, city and tel
        }

        [HttpPost]      //submits user's entry
        public ActionResult IndexPeople(string searchBy, string searchByLetter)
        {
            if (searchBy == "city")
                return View(actress.Where(n => n.City.ToLower().StartsWith(searchByLetter.ToLower()) || searchByLetter == null).ToList());      
            else
                return View(actress.Where(n => n.Name.ToLower().StartsWith(searchByLetter.ToLower()) || searchByLetter == null).ToList());
                //StartsWith - displays item/items(Name, City) with the letter/letters given as input for search 
        }
               
        [HttpGet]
        public ActionResult Create()        //add name, city and telephone #
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)  //FormCollection - captures the form's values within the controller
        {
            People people = new People();       //object for People Class
            people.PersonId = Convert.ToInt32(formCollection["PersonId"]);
            people.Name = formCollection["Name"];
            people.City = formCollection["City"];
            people.Telephone = Convert.ToInt32(formCollection["Telephone"]);

            actress.Add(people);        //adding new person (name, city and telephone #
            return RedirectToAction("IndexPeople");  // leading to IndexPeople view
        }

        [HttpGet]
        public ActionResult Delete(int id)      //displaying the Id to delete
        {
            try
            {
                People person = actress.Single(p => p.PersonId == id);      //*Single = deleting single row/Id in the table
                return View(person);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)  //*FormCollection =  access the form element in action method of the controller 
        {
            People ppl = actress.Single(p => p.PersonId == id);        //with Lambda expression
            ppl.PersonId = Convert.ToInt32(collection["PersonId"]);
            ppl.Name = collection["Name"];
            ppl.City = collection["City"];
            ppl.Telephone = Convert.ToInt32(collection["Telephone"]);

            actress.Remove(ppl);                                       //deleting Id/row
            return RedirectToAction("IndexPeople");                    //directing back to main (People) page
        }

        public ActionResult IndexPeoplePartialView()
        {
            return View(actress);
        }
    }
}



