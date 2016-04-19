using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace SaveEmployee.Controllers
{
    public class CoursesController : Controller
    {
        private SaveDepartmentContext db = new SaveDepartmentContext(); 

       
        // GET: Courses/Create
        public ActionResult Create()
        {
            //ViewBag.DepartmentSelection = db.Departments.Select(h => new SelectListItem
            //{
            //    Value = h.Name,
            //    Text = h.Name
            //});
            
            return View();
        }

        public JsonResult IsCourseCodeExists(string code)
        {
            return Json(!db.Departments.Any(x => x.Code == code), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCourseNameExists(string name)
        {
            return Json(!db.Departments.Any(x => x.Name == name), JsonRequestBehavior.AllowGet);
        }
        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Credit,Description,Department,Semester")] Course course)
        {
            ViewBag.Message = "Course Not saved";
            ViewBag.Status = "Error";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Course Saved Successfuly";
                    
                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Course Code and Name required";
                }
                ModelState.Clear();
            }
            //return View(department);
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
