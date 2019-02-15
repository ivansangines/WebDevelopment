using ModelValidationDataAnnotations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidationDataAnnotations.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewStudent()
        {
            ViewBag.Message = "";
            Student st = new Student();
            return View(st);
        }

        [HttpPost]
        public ActionResult AddNewStudent(Student st)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                // write st to DB – to do
                ViewBag.Message = "Student added successfully..";
                ModelState.Clear(); // to clear the form text fields
                return View(new Student());
                
            }            
            else
            {
                ViewBag.Message = "Invalid entry.."; //Never showing it?
                return View(st);
            }
            
        }

        public ActionResult ListStudents()
        {
            ViewBag.Message = "";
            // Get Students from DB
            List<Student> STList = new List<Student>();
            Student s1 = new Student

            {
                FirstName = "Bill",

                LastName = "Baker",
                StudentID = 1234,
                Major = "EE",
                Email = "bill@yahoo.com",
                Telephone = 23333,
                TestScore = 85
            };
            if (TempData["StudentID"] != null)

            {
                if ((int)(TempData["StudentID"]) != 1234)
                    STList.Add(s1);

            }
            else
                STList.Add(s1);
            Student s2 = new Student
            {
                FirstName = "Sally",
                LastName = "Simpson",
                StudentID = 1235,
                Major = "EE",
                Email = "sally@yahoo.com",
                Telephone = 23353,
                TestScore = 87
            };
            STList.Add(s2);
            return View(STList);


        }

        public ActionResult UpdateStudent(int id=1234)

        {
            ViewBag.Message = "";
            Student st = null;
            if (id == 1234)

            {
                st = new Student

                {
                    FirstName = "Bill",
                    LastName = "Baker",
                    StudentID = 1234,
                    Major = "CS",
                    Email = "bill@yahoo.com",
                    Telephone = 23333,
                    TestScore = 85
                };

            }
            if (id == 1235)

            {
                st = new Student

                {
                    FirstName = "Sally",
                    LastName = "Simpson",
                    StudentID = 1235,
                    Major = "EE",
                    Email = "sally@yahoo.com",
                    Telephone = 23353,
                    TestScore = 87
                };
            }
            return View(st);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student st)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                // update student in DB
                ModelState.Clear();
                ViewBag.Message = "Student Updated successfully";
                
            }
            return View(new Student());
        }

        public ActionResult DeleteStudent(int id)
        {
            ViewBag.Message = "";
            // Delete student in DB
            TempData["StudentID"] = id;
            ViewBag.Message = "Student Updated successfully";
            return RedirectToAction("ListStudents");
        }
    }
}