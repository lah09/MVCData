using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCData.Controllers
{
    public class GuessingGameController : Controller
    {        
        // GET: GuessingGame
        [HttpGet]
        public ActionResult GuessingGameForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuessingGameForm(int guessNum)
        {
            if (Session["randNum"] == null)
            {
                Random rand = new Random();
                Session["randNum"] = rand.Next(1, 101);
                Session["guessAmount"] = 0;
            }
            Session["guessAmount"] = (int)Session["guessAmount"] + 1;
            Session["guess"] = guessNum;
            int randNum = (int)Session["randNum"];

            if (guessNum < randNum)
            {
                ViewBag.Message = "Your number is too low!";

            }
            else if (guessNum > randNum)
            {
                ViewBag.Message = "Your number is too high!";

            }
            else if (guessNum == randNum)
            {
                ViewBag.Message = "You got it!";
            }
            else
            {
                ViewBag.Message = "Ooops, wrong input!";
            }

            ViewBag.NumberOfGuess = "Number of guess: " + Session["guessAmount"];
            return View();
        }
    }
}