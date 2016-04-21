using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();

        // GET: Teachers/Create
        public ActionResult Create()
        {
            GenerateDropDownValue();
            return View();
        }
        public JsonResult IsEmailExists(string email)
        {
            return Json(!db.Teachers.Any(x => x.Email == email), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Designation,Credit,Name,Contact,Address,Department")] Teacher teacher)
        {
            GenerateDropDownValue();

            ViewBag.Message = "Course Not saved";
            ViewBag.Status = "Error";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Teachers.Add(teacher);
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

        private void GenerateDropDownValue()
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

            var designations = designationManager.GetDesignation();

            List<SelectListItem> designationList = new List<SelectListItem>();

            foreach (var designation in designations)
            {
                designationList.Add(

                    new SelectListItem()
                    {
                        Value = designation,
                        Text = designation
                    }
                    );
            }

            ViewBag.Designations = designationList;
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
