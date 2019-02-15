using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardMVC.Models;
using WizardMVC.Utils;

namespace WizardMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult WizStep1()
        {
            // user can come to this step from two different ways
            // 1. starting the wizard, 2. user came back from step 2
            CustomerInfo cinfo = null;
            if (SessionFacade.WIZSTEP1 == null) // starting from beginning
                cinfo = new CustomerInfo();
            else
                cinfo = SessionFacade.WIZSTEP1; // user is coming back from step 2
            return View(cinfo); //the info provided in the form will athomatically bind to cinfo
        }
        [HttpPost]
        public ActionResult WizStep1(CustomerInfo cinfo)
        {
            ModelState.Remove("StreetAddress"); //Removing from modelstate makes the program not having to check for this values since they are empty and will complain
            ModelState.Remove("City");
            ModelState.Remove("State");
            ModelState.Remove("Telephone");
            ModelState.Remove("CellPhone");
            ModelState.Remove("CustomerPin");
            ModelState.Remove("CardNumber");
            ModelState.Remove("ExpirationDate");
            if (ModelState.IsValid)
            {
                SessionFacade.WIZSTEP1 = cinfo; 
                return RedirectToAction("WizStep2");
            }
            return View(cinfo);
        }

        public ActionResult WizStep2()
        {
            // some one can come to this step three different ways
            // 1. directly to this step without going through step 1
            // 2. From step1 to this step 2
            // 3. Back from step 3
            if (SessionFacade.WIZSTEP1 == null) // some one skipped step 1
                return RedirectToAction("WizStep1");
            else
            {
                CustomerInfo ci = null;
                if (SessionFacade.WIZSTEP2 != null) // coming back from step 3
                    ci = SessionFacade.WIZSTEP2;
                else
                    ci = SessionFacade.WIZSTEP1; // from step 1 to this step2
                return View(ci); //will copy the attributes from wizz step1 and add the news from wizz step2
            }
        }
        [HttpPost]
        public ActionResult WizStep2(string btnPrev, string btnNext, CustomerInfo cinfo)
        {
            if (btnPrev != null)
            {
                if (btnPrev.ToUpper() == "PREV")
                {
                    SessionFacade.WIZSTEP2 = null; // remove data for step 2
                    return RedirectToAction("WizStep1");
                }
            }
            if (SessionFacade.WIZSTEP1 == null)
                return RedirectToAction("WizStep1");
            else
            {
                CustomerInfo ci = SessionFacade.WIZSTEP1; //new object?
                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Email");
                ModelState.Remove("Telephone");
                ModelState.Remove("CellPhone");
                ModelState.Remove("CustomerPin");
                ModelState.Remove("CardNumber");
                ModelState.Remove("ExpirationDate");
                if (ModelState.IsValid)
                {
                    if (btnNext != null)
                    {
                        if (btnNext.ToUpper() == "NEXT")
                        {
                            ci.StreetAddress = cinfo.StreetAddress;
                            ci.City = cinfo.City;
                            ci.State = cinfo.State;
                            SessionFacade.WIZSTEP2 = ci;
                            return RedirectToAction("WizStep3");
                        }
                    }
                }
            }
            return View(cinfo);
        }

        public ActionResult WizStep3()
        {
            // 3 ways some one can come to this step
            if (SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            {
                CustomerInfo ci = null;
                if (SessionFacade.WIZSTEP3 != null) // from step 4
                    ci = SessionFacade.WIZSTEP3;
                else
                    ci = SessionFacade.WIZSTEP2; //from step 2
                return View(ci);
            }
        }
        [HttpPost]
        public ActionResult WizStep3(string btnPrev, string btnNext, CustomerInfo cinfo)
        {
            if (btnPrev != null)
            {
                if (btnPrev.ToUpper() == "PREV")
                {
                    SessionFacade.WIZSTEP3 = null; // remove data for step 2
                    return RedirectToAction("WizStep2");
                }
            }
            if (SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            { // normal flow from step 2 to step 3
                CustomerInfo ci = SessionFacade.WIZSTEP2;
                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Email");
                ModelState.Remove("StreetAddress");
                ModelState.Remove("City");
                ModelState.Remove("State");
                ModelState.Remove("CardNumber");
                ModelState.Remove("ExpirationDate");


                if (ModelState.IsValid)
                {
                    if (btnNext != null)
                    {
                        if (btnNext.ToUpper() == "NEXT")
                        {
                            ci.Telephone = cinfo.Telephone;
                            ci.CellPhone = cinfo.CellPhone;
                            ci.CustomerPin = cinfo.CustomerPin;
                            SessionFacade.WIZSTEP3 = ci;
                            return RedirectToAction("WizStep4");
                        }
                    }
                }
            }
            return View(cinfo);
        }

        public ActionResult WizStep4()
        {
            if (SessionFacade.WIZSTEP3 == null)
                return RedirectToAction("WizStep3");
            else
            {
                CustomerInfo ci = null;
                if (SessionFacade.WIZSTEP4 != null) //coming back from confirm
                    ci = SessionFacade.WIZSTEP4;
                else
                    ci = SessionFacade.WIZSTEP3; //coming from step 3

                return View(ci);
            }
        }

        [HttpPost]
        public ActionResult WizStep4(string btnPrev, string btnNext, CustomerInfo cinfo)
        {
            if (btnPrev != null)
            {
                if (btnPrev.ToUpper() == "PREV")
                {
                    SessionFacade.WIZSTEP4 = null; // remove data for step 3
                    return RedirectToAction("WizStep3");
                }
            }
            if (SessionFacade.WIZSTEP3 == null)
                return RedirectToAction("WizStep3");
            else
            { // normal flow from step 3 to step 4
                CustomerInfo ci = SessionFacade.WIZSTEP3;
                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Email");
                ModelState.Remove("StreetAddress");
                ModelState.Remove("City");
                ModelState.Remove("State");
                ModelState.Remove("Telephone");
                ModelState.Remove("CellPhone");
                ModelState.Remove("CustomerPin");


                if (ModelState.IsValid)
                {
                    if (btnNext != null)
                    {
                        if (btnNext.ToUpper() == "NEXT")
                        {
                            ci.CardNumber = cinfo.CardNumber;
                            ci.ExpirationDate = cinfo.ExpirationDate;
                            SessionFacade.WIZSTEP4 = ci;
                            return RedirectToAction("Confirm");
                        }
                    }
                }
            }
            return View(cinfo);
        }

        public ActionResult Confirm()
        {
            if (SessionFacade.WIZSTEP4 == null)
                return RedirectToAction("WizStep4");
            else
            {
                CustomerInfo ci = SessionFacade.WIZSTEP4;
                return View(ci);
            }
        }
        [HttpPost]
        public ActionResult Confirm(string btnPrev, string btnConfirm)
        {
            if (SessionFacade.WIZSTEP4 == null)
                return RedirectToAction("WizStep4");
            else
            {
                // normal flow - came here from step 4
                if (btnConfirm != null)
                {
                    if (btnConfirm.ToUpper() == "CONFIRM")
                    {                        
                        CustomerInfo ci = SessionFacade.WIZSTEP4;
                        // write ci to DB
                        ViewBag.Message = "Customer registered successfully..";
                        SessionFacade.WIZSTEP1 = null;
                        SessionFacade.WIZSTEP2 = null;
                        SessionFacade.WIZSTEP3 = null;
                        SessionFacade.WIZSTEP4 = null;

                    }
                }
                if (btnPrev != null)
                {
                    if (btnPrev.ToUpper() == "PREV")
                        return RedirectToAction("WizStep4");
                }
            }
            return View();
        }
    }
}
