using MVCRoutes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id != null)
                ViewBag.Message = "Welcome to MVC! " + id.ToString();
            else
                ViewBag.Message = "Welcome to MVC! - no id received";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // parameter names have to match the names declared in the View
        public ActionResult FormDataTest(string fname, string lname, string street, string city, string state)
        {
            if ((fname != null) && (lname != null) && (street != null) && (city != null) && (state != null))
            {
                Address a1 = new Address
                {
                    Street = street,
                    State = state,
                    City = city
                };
                UserInfo ui = new UserInfo
                {
                    FirstName = fname,
                    LastName = lname,
                    UserAddress = a1
                };
                if (DBLayer.WriteUserToDB(ui))
                    ViewBag.Message = "Data Updated successfully..";
            }
            return View("FormDataTest");
        }

        // triggered when the page is first asked for
        public ActionResult ModelBindingTest()
        {
            Address a1 = new Address
            {
                City = "Bridgeport",
                State = "CT",
                Street = "1020"
            };
            UserInfo ui = new UserInfo
            {
                FirstName = "Bill",
                LastName = "Baker",
                UserAddress = a1
            };

            return View("ModelBindingTest", ui);
        }

        [HttpPost] // triggered when page is posted back
        public ActionResult ModelBindingTest(UserInfo ui)
        {
            if (DBLayer.WriteUserToDB(ui))
                ViewBag.Message = "Data Updated successfully..";

            return View("ModelBindingTest", ui);
        }

        public ActionResult CreateProduct()
        {
            return View("CreateProduct");
        }
        [HttpPost]
        public ActionResult CreateProduct([Bind(Exclude = "Price")] Product pr)
        { // validation will be excluded for Price field
            if (ModelState.IsValid)
            {
                // DBLayer.CreateProduct(pr); to do
                ViewData["message"] = "Product ceated successfully..";
            }
            return View("CreateProduct");
        }

    }
}