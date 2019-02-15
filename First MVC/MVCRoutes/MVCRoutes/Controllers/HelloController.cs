using MVCRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRoutes.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Greet(DateTime? id)
        {
            ViewBag.GreetInfo = "Greetings from new Route, Time! " + id.ToString();
            return View();
        }

        public ActionResult Hello2(string pname) //string theName)
                                             // the parameter has to be id
        {                                   // to use default route in RoutesConfig.cs
            HelloPerson person = new HelloPerson();
            person.Name = pname; //changed id for pname in the default routing table
            person.Id = 1234;
            ViewBag.PersonData = person;
            return View();
        }
    }
}