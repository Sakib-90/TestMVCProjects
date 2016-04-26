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

namespace SaveEmployee.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        DepartmentManager departmentManager = new DepartmentManager();

        
        // GET: Students/Create
        public ActionResult Create()
        {
            GenerateDropDownValue();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentRegNo,StudentName,StudentContact,StudentAddress,StudentDepartmentCode,StudentEmail,StudeRegDate")] Student student)
        {
            GenerateDropDownValue();

            ViewBag.Message = "Student Not saved";
            ViewBag.Status = "Error";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Student Saved Successfuly";

                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Student Email and Name required";
                }
                ModelState.Clear();
            }

            return View();
        }


        public JsonResult IsEmailExists(string studentEmail)
        {
            return Json(!db.Students.Any(x => x.StudentEmail == studentEmail), JsonRequestBehavior.AllowGet);
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
                        Value = department.DepartmentCode,
                        Text = department.DepartmentName
                    }
                    );
            }

            ViewBag.Departments = departmentList;

            //var designations = designationManager.GetDesignation();

            //List<SelectListItem> designationList = new List<SelectListItem>();

            //foreach (var designation in designations)
            //{
            //    designationList.Add(

            //        new SelectListItem()
            //        {
            //            Value = designation,
            //            Text = designation
            //        }
            //        );
            //}

            //ViewBag.Designations = designationList;
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
