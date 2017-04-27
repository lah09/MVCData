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
    public class PeopleController : Controller //Inheritance
    {
        // GET: People
        static IList<People> actress = new List<People> //static variable exists in memory for all the objects of that class
        //IList = more control over a collection: Add, Delete, etc
{
new People() {PersonId=1, Name="Salma Hayek", City="New York City", Telephone="0701234567" }, //new object List
new People() {PersonId=2, Name="Natalie Portman", City="California", Telephone="0731023456" },
new People() {PersonId=3, Name="Angelina Jolie", City="Chicago", Telephone="0702013456" },
new People() {PersonId=4, Name="Keira Knightley", City="Texas", Telephone="0702354678" },
new People() {PersonId=5, Name="Whoopi Goldberg", City="Oregon", Telephone="0701023457" },
new People() {PersonId=6, Name="Alicia Silverstone", City="Florida", Telephone="0738074123" },
new People() {PersonId=7, Name="Anne Hathaway", City="Michigan", Telephone="0732347568" },
new People() {PersonId=8, Name="Ashley Judd", City="Kentucky", Telephone="0731025634" },
new People() {PersonId=9, Name="Nicole Kidman", City="New Jersey", Telephone="0703456107" },
new People() {PersonId=10, Name="Halle Berry", City="Washington", Telephone="0739153624" },
new People() {PersonId=11, Name="Kim Kardashian", City="Ohio", Telephone="0737910234" },
};

        [HttpGet] //displays a form for user entry
        public ActionResult IndexPeople()   //Method
        {
            return View(actress); //displays all the List of name, city and tel
        }

        [HttpPost] //submits user's entry
        public ActionResult IndexPeople(string searchBy, string searchByLetter)
        {
            if (searchBy == "city")
                return View(actress.Where(n => n.City.ToLower().StartsWith(searchByLetter.ToLower()) || searchByLetter == null).ToList());
            //enable user to search with lowercase letter/s
            else
                return View(actress.Where(n => n.Name.ToLower().StartsWith(searchByLetter.ToLower()) || searchByLetter == null).ToList());
            //StartsWith - displays item/items(Name, City) with the letter/letters given as input for search 
        }

        //------------------------------------------------------------------------------------------------

        public ActionResult PeoplePartialIndex()        //People List Partial View
        {
            return View(actress);       //"View" - generates a result back
        }

        public PartialViewResult PeoplePartialView(int id) //action for Partial View
        {
            People onePerson = actress.Single(p => p.PersonId == id); //one tile for every person in People's list
            return PartialView("_PersonInPeople", onePerson); //calling Partial View with the value of the instance "onePerson"
        }

        //-------------------------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult Create() //add name, city and telephone #
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection) //FormCollection - captures the form's values within the controller
        {
            if (ModelState.IsValid)     //instead of try and catch
            {
                People people = new People(); //object for People Class
                people.PersonId = Convert.ToInt32(formCollection["PersonId"]);
                people.Name = formCollection["Name"];
                people.City = formCollection["City"];
                people.Telephone = formCollection["Telephone"];
                actress.Add(people); //adding new person (name, city and telephone #
                return RedirectToAction("IndexPeople"); //leading to IndexPeople view
            }
            return View("Error");   //instead of try and catch            
        }

        public ActionResult AjaxCreate() //GET for AjaxCreate. Add a row with details of name, city and telephone #
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AjaxCreate([Bind(Include = "PersonId, Name, City, Telephone")] FormCollection formCollection) //add name, city and telephone #
        {
            if (ModelState.IsValid)     //instead of try and catch
            {
                People people = new People(); //object for People Class
                people.PersonId = Convert.ToInt32(formCollection["PersonId"]);
                people.Name = formCollection["Name"];
                people.City = formCollection["City"];
                people.Telephone = formCollection["Telephone"];
                actress.Add(people); //adding new row (person, name, city and telephone #)
                return Content("");
            }
            return View("Error");   //instead of try and catch
        }

        public ActionResult PeoplePartialUpdate()       //AJAX Partial Create [HttpGet]
        {
            return PartialView(actress);                //update displaying People List
        }
        //-------------------------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult Delete(int id) //displaying the Id to delete
        {
            try
            {
                People person = actress.Single(p => p.PersonId == id); //*Single = deleting single row/Id in the table
                return View(person);
            }
            catch (Exception)
            {
                return View("Error"); //Error handling - wrong Id number
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) //*FormCollection = access the form element in ACTION METHOD of the CONTROLLER
        {
            try
            {                                  //Lambda Expression
                People ppl = actress.Single(p => p.PersonId == id);
                ppl.PersonId = Convert.ToInt32(collection["PersonId"]);
                ppl.Name = collection["Name"];
                ppl.City = collection["City"];
                ppl.Telephone = collection["Telephone"];
                actress.Remove(ppl); //deleting Id/row
                return RedirectToAction("IndexPeople"); //directing back to Main (People) Page
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult PeoplePartialDelete(int id, FormCollection delRow)
        {
            try
            {
                People delPerson = actress.Single(p => p.PersonId == id);
                delPerson.PersonId = Convert.ToInt32(delRow["PersonId"]);
                delPerson.Name = delRow["Name"];
                delPerson.City = delRow["City"];
                delPerson.Telephone = delRow["Telephone"];
                actress.Remove(delPerson); //deleting Id/row                         
                return Content(""); /*PartialView("PeoplePartialDelete", actress.ToList()); --- changed to Content("") otherwise 2 tables appear*/
            }
            catch
            {
                return View("Error");
            }
        }
    }
}