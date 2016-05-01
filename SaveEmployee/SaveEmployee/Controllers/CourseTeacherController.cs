using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class CourseTeacherController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        // GET: CourseTeacher
        public ActionResult AssignCourse()
        {
            List<Department> allDepartments = new List<Department>();
            List<Teacher> allTeachers = new List<Teacher>();
            List<Course> allCourses = new List<Course>();

            double creditToTake = 0.0;
            double remainingCredit = 0.0;


            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }

            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName");
            ViewBag.TeachersName = new SelectList(allTeachers, "TeacherEmail", "TeacherName");
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode");

            ViewBag.CreditToTake = creditToTake.ToString();
            ViewBag.RemainingCredit = remainingCredit.ToString();
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourse(CourseTeacher courseTeacher)
        {
            List<Department> allDepartments = new List<Department>();
            List<Teacher> allTeachers = new List<Teacher>();
            List<Course> allCourses = new List<Course>();

            double creditToTake = 0.0;
            double remainingCredit = 0.0;

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
            ViewBag.RemainingCredit = remainingCredit.ToString();
            
            if (ModelState.IsValid)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    courseTeacher.CourseTeacherCourseCredit = db.Courses.Where(c => c.CourseCode == courseTeacher.CourseTeacherCourseCode).Select(p => (double?)p.CourseCredit).Single();

                    courseTeacher.CourseTeacherTeacherName =
                        db.Teachers.Where(a => a.TeacherEmail.Equals(courseTeacher.CourseTeacherEmail))
                            .Select(p => p.TeacherName)
                            .Single();
                    db.CoursesTeachers.Add(courseTeacher);
                    db.SaveChanges();
                    ModelState.Clear();
                    courseTeacher = null;
                }
            }
            return View(courseTeacher);
        }

        public JsonResult IsCodeExists(string courseTeacherCourseCode)
        {
            return Json(!db.CoursesTeachers.Any(x => x.CourseTeacherCourseCode == courseTeacherCourseCode), JsonRequestBehavior.AllowGet);
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
            double? totalCredit = 0.0;
            double? creditToTake = 0.0;

            if (teacherName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    creditToTake = (db.Teachers.Where(p => p.TeacherEmail == teacherName).Select(p => (double?)p.TeacherCredit)).Single();
                    double? credit = db.CoursesTeachers.Where(p=>p.CourseTeacherEmail==teacherName).Sum(e =>(double?) e.CourseTeacherCourseCredit);
                    if (credit == null)
                    {
                        totalCredit = 0.0;
                    }
                    else
                    {
                        totalCredit = credit;
                    }
                    
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = creditToTake-totalCredit,
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
                    allCourses = db.Courses.Where(a => a.CourseDepartmentCode.Equals(departmentName)).OrderBy(a => a.CourseCode).ToList();
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
        [HttpGet]
        public JsonResult GetCourseName(string teacherName)
        {
            string course="";

            if (!string.IsNullOrEmpty(teacherName))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    course = db.Courses.Where(c => c.CourseCode == teacherName).Select(p => p.CourseName).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = course,
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
        public JsonResult GetCourseCredit(string teacherName)
        {
            double? credit = 0.0;

            if (!string.IsNullOrEmpty(teacherName))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    credit = db.Courses.Where(c => c.CourseCode == teacherName).Select(p =>(double?) p.CourseCredit).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = credit,
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