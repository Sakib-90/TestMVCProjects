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

namespace UniversityApplication.Controllers
{
    public class DepartmentsController : Controller
    {
        private SaveDepartmentContext db = new SaveDepartmentContext();

        // GET: Departments
        public ActionResult ShowAllDepartments()
        {
            return View(db.Departments.ToList());
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        public JsonResult IsDepartmentCodeExists(string code)
        {
            return Json(!db.Departments.Any(x => x.Code == code), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult IsDepartmentNameExists(string name)
        {
            return Json(!db.Departments.Any(x => x.Name == name), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name")] Department department)
        {
            ViewBag.Message = "Department Not saved";
            ViewBag.Status = "Error";
            
            if (ModelState.IsValid)
            {
                try
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Department Saved Successfuly";
                    //TempData["shortMessage"] = "Department Saved Successfuly";

                    //ViewBag.Message = TempData["shortMessage"].ToString();
                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Department Code and Name required";
                }
                
                //return RedirectToAction("Create");
                ModelState.Clear();
               // return View();
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
