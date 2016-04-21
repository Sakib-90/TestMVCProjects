using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class CourseTeacherController : Controller
    {
        
        // GET: CourseTeacher
        public ActionResult AssignCourse()
        {


            List<Department> allDepartments = new List<Department>();
            List<Teacher> allTeachers = new List<Teacher>();

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.Name).ToList();
            }

            ViewBag.Departments = new SelectList(allDepartments, "Name", "Name");
            ViewBag.TeachersName = new SelectList(allTeachers,"Name","Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourse(CourseTeacher courseTeacher)
        {
            List<Department> allDepartments = new List<Department>();
            List<Teacher> allTeachers = new List<Teacher>();

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.Name).ToList();

                if (courseTeacher != null && courseTeacher.Teacher != null)
                {
                    allTeachers =
                        db.Teachers.Where(a => a.Department.Equals(courseTeacher.Department))
                            .OrderBy(a => a.Name)
                            .ToList();
                }
            }

            ViewBag.Departments = new SelectList(allDepartments, "Name", "Name",courseTeacher.Department);
            ViewBag.TeachersName = new SelectList(allTeachers, "Name", "Name",courseTeacher.Teacher);

            if (ModelState.IsValid)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.CoursesTeachers.Add(courseTeacher);
                    db.SaveChanges();
                    ModelState.Clear();
                    courseTeacher = null;
                    //ViewBag.Message = "Successfully submitted";
                }
            }
            else
            {
                //ViewBag.Message = "Failed! Please try again";
            }
            return View(courseTeacher);

        }

        [HttpGet]
        public JsonResult GetTeachers(string departmentName)
        {
            List<Teacher> allTeachers = new List<Teacher>();
           
            if (departmentName!=null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    allTeachers = db.Teachers.Where(a => a.Department.Equals(departmentName)).OrderBy(a => a.Name).ToList();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = allTeachers,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        
    }
}