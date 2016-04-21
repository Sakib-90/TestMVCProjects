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
            List<Course> allCourses = new List<Course>();

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.Name).ToList();
            }

            ViewBag.Departments = new SelectList(allDepartments, "Name", "Name");
            ViewBag.TeachersName = new SelectList(allTeachers, "Email", "Name");
            ViewBag.CourseCode = new SelectList(allCourses,"Code","Code");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourse(CourseTeacher courseTeacher)
        {
            List<Department> allDepartments = new List<Department>();
            List<Teacher> allTeachers = new List<Teacher>();
            List<Course> allCourses = new List<Course>();

            double credit = 0.0;

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.Name).ToList();

                if (courseTeacher != null) 
                {
                    if (courseTeacher.Teacher != null)
                    {
                        allTeachers =
                            db.Teachers.Where(a => a.Department.Equals(courseTeacher.Department))
                                .OrderBy(a => a.Name)
                                .ToList();
                    }

                    if (courseTeacher.CourseCode != null)
                    {
                       allCourses =
                            db.Courses.Where(a => a.Code.Equals(courseTeacher.CourseCode))
                                .OrderBy(a => a.Name)
                                .ToList();
                    }
                }
            }

            ViewBag.Departments = new SelectList(allDepartments, "Name", "Name",courseTeacher.Department);
            ViewBag.TeachersName = new SelectList(allTeachers, "Email", "Name", courseTeacher.Teacher);
            ViewBag.CourseCode = new SelectList(allCourses, "Code", "Code",courseTeacher.CourseCode);

            //string email = courseTeacher.Teacher;

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    //credit = Convert.ToDouble(db.Teachers.Where(a => a.Email.Equals(email)));
                
            //  //  allDepartments = db.Departments.OrderBy(a => a.Name).ToList();

            //    if (courseTeacher != null)
            //    {
            //        if (courseTeacher.Teacher != null)
            //        {
            //            //credit = Convert.ToDouble(db.Teachers.Where(a => a.Email.Equals(email)));

            //            credit = 10;

            //        }
                    
            //    }
            //}

            //ViewBag.CreditToTake = credit;


            if (ModelState.IsValid)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.CoursesTeachers.Add(courseTeacher);
                    db.SaveChanges();
                    ModelState.Clear();
                    courseTeacher = null;
                }
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

        

        [HttpGet]
        public JsonResult GetCourseCode(string departmentName)
        {
            List<Course> allCourses = new List<Course>();

            if (departmentName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    allCourses = db.Courses.Where(a => a.Department.Equals(departmentName)).OrderBy(a => a.Name).ToList();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = allCourses,
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