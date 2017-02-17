using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCData.Controllers
{
    public class FeverCheckController : Controller
    {
        // GET: FeverCheck      

        [HttpGet]
        public ActionResult FeverCheckForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeverCheckForm(float temperature)
        {
            if (temperature <= 36.4)
            {
                ViewBag.Message = "You have Hypothermia!";
            }
            else if (temperature >= 37.6)
            {
                ViewBag.Message = "You have a fever!";
            }
            else if (temperature >= 36.5 || temperature <= 37.5)
            {
                ViewBag.Message = "You're fine, nothing to worry about!";
            }
            else
            {
                ViewBag.Message = "Something went wrong!!!";
            }
            return View();
        }
    }
}