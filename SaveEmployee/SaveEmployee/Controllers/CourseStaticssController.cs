using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class CourseStaticssController : Controller
    {
        // GET: CourseStaticss
        public ActionResult CourseStatistics()
        {
            List<Department> allDepartments = new List<Department>();
            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }
            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName");

            return View();
        }
    }
}