using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SaveEmployee.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace SaveEmployee.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        DepartmentManager departmentManager = new DepartmentManager();
       
        // GET: Courses/Create
        public ActionResult Create()
        {

            var departments = departmentManager.GetDepartments();

            //List<SelectListItem> departmentList = new List<SelectListItem>();

            //foreach (var department in departments)
            //{
            //    departmentList.Add(

            //        new SelectListItem()
            //        {
            //            Value = department.Name,
            //            Text = department.Name
            //        }
            //        );
            //}
            List<SelectListItem> departmentList = departments.Select(department => new SelectListItem()
            {
                Value = department.Name, Text = department.Name
            }).ToList();


            ViewBag.Departments = departmentList;
            return View();
        }

        public JsonResult IsCourseCodeExists(string code)
        {
            return Json(!db.Courses.Any(x => x.Code == code), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCourseNameExists(string name)
        {
            return Json(!db.Courses.Any(x => x.Name == name), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Credit,Description,Department,Semester")] Course course)
        {
            var departments = departmentManager.GetDepartments();

            List<SelectListItem> departmentList = new List<SelectListItem>();

            foreach (var department in departments)
            {
                departmentList.Add(

                    new SelectListItem()
                    {
                        Value = department.Name,
                        Text = department.Name
                    }
                    );
            }

            ViewBag.Departments = departmentList;
            
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
