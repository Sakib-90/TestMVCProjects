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

            double creditToTake = 1.0;
            
            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }

            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName");
            ViewBag.TeachersName = new SelectList(allTeachers, "TeacherEmail", "TeacherName");
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode");
            ViewBag.CreditToTake = creditToTake.ToString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourse(CourseTeacher courseTeacher)
        {
            List<Department> allDepartments = new List<Department>();
            List<Teacher> allTeachers = new List<Teacher>();
            List<Course> allCourses = new List<Course>();

            double creditToTake = 2.0;

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();

                if (courseTeacher != null) 
                {
                    if (courseTeacher.CourseTeacherEmail != null)
                    {
                        allTeachers =
                            db.Teachers.Where(a => a.TeacherDepartmentCode.Equals(courseTeacher.CourseTeacherDepartmentCode))
                                .OrderBy(a => a.TeacherName)
                                .ToList();
                    }

                    if (courseTeacher.CourseTeacherCourseCode != null)
                    {
                       allCourses =
                            db.Courses.Where(a => a.CourseCode.Equals(courseTeacher.CourseTeacherCourseCode))
                                .OrderBy(a => a.CourseName)
                                .ToList();
                    }

                }
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                creditToTake = (db.Teachers.Where(p => p.TeacherEmail == courseTeacher.CourseTeacherEmail).Select(p => p.TeacherCredit)).Single();
            }

            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName", courseTeacher.CourseTeacherDepartmentCode);
            ViewBag.TeachersName = new SelectList(allTeachers, "TeacherEmail", "TeacherName", courseTeacher.CourseTeacherEmail);
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode", courseTeacher.CourseTeacherCourseCode);
            ViewBag.CreditToTake = creditToTake.ToString();
            
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
                    allTeachers = db.Teachers.Where(a => a.TeacherDepartmentCode.Equals(departmentName)).OrderBy(a => a.TeacherName).ToList();
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
        public JsonResult GetTeachersCreditToTake(string teacherName)
        {
            double creditToTake = 0.0;

            if (teacherName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    creditToTake = (db.Teachers.Where(p => p.TeacherEmail == teacherName).Select(p => p.TeacherCredit)).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = creditToTake,
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
        public JsonResult GetTeachersRemainingCredit(string teacherName)
        {
            double remainingCredit = 0.0;

            if (teacherName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    remainingCredit = (db.Teachers.Where(p => p.TeacherEmail == teacherName).Select(p => p.TeacherCredit)).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = remainingCredit,
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
                    allCourses = db.Courses.Where(a => a.CourseDepartmentCode.Equals(departmentName)).OrderBy(a => a.CourseName).ToList();
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