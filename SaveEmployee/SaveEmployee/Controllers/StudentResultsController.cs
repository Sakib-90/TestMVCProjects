using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaveEmployee.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace SaveEmployee.Controllers
{
    public class StudentResultsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        ResultManager resultManager = new ResultManager();

        // GET: StudentResults/Create
        public ActionResult SaveResult()
        {
            List<Student> allRegisteredStudents = new List<Student>();
            List<CourseStudent> allCourses = new List<CourseStudent>();
            GenerateDropDownValue();

            string studentName = "";
            string studentEmail = "";
            string studentDepartment = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                allRegisteredStudents = db.Students.OrderBy(a => a.StudentRegNo).ToList();
            }
            ViewBag.Students = new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo");
            ViewBag.CourseCode = new SelectList(allCourses, "CourseStudentCourse", "CourseStudentCourse");
            ViewBag.StudentName = studentName;
            ViewBag.StudentEmail = studentEmail;
            ViewBag.StudentDepartment = studentDepartment;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveResult([Bind(Include = "StudentResultRegNo,StudentResultName,StudentResultEmail,StudentResultDepartmentCode,StudentResultCourse,StudentResultGrade")] StudentResult studentResult)
        {
            List<Student> allRegisteredStudents = new List<Student>();
            List<Course> allCourses = new List<Course>();

            GenerateDropDownValue();
            string studentName = "";
            string studentEmail = "";
            string studentDepartment = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                allRegisteredStudents = db.Students.OrderBy(a => a.StudentRegNo).ToList();
            }
            ViewBag.Students = new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo", studentResult.StudentResultRegNo);
            ViewBag.CourseCode = new SelectList(allCourses, "CourseStudentCourse", "CourseStudentCourse", studentResult.StudentResultCourse);
            ViewBag.StudentName = studentName;
            ViewBag.StudentEmail = studentEmail;
            ViewBag.StudentDepartment = studentDepartment;

            if (ModelState.IsValid)
            {
                db.StudentResults.Add(studentResult);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("SaveResult");
            }

            return View(studentResult);
        }

        private void GenerateDropDownValue()
        {
            var results = resultManager.GetResults();

            List<SelectListItem> resultList = new List<SelectListItem>();

            foreach (var result in results)
            {
                resultList.Add(

                    new SelectListItem()
                    {
                        Value = result,
                        Text = result
                    }
                    );
            }

            ViewBag.Result = resultList;
        }
        public JsonResult GetStudentName(string studentRegNo)
        {
            string name = "";

            if (!string.IsNullOrEmpty(studentRegNo))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    name = db.Students.Where(c => c.StudentRegNo == studentRegNo).Select(p => p.StudentName).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = name,
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

        public JsonResult GetStudentEmail(string studentRegNo)
        {
            string email = "";

            if (!string.IsNullOrEmpty(studentRegNo))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    email = db.Students.Where(c => c.StudentRegNo == studentRegNo).Select(p => p.StudentEmail).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = email,
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

        public JsonResult GetStudentDepartment(string studentRegNo)
        {
            string departmentCode = "";
            string department = "";

            if (!string.IsNullOrEmpty(studentRegNo))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    departmentCode = db.Students.Where(c => c.StudentRegNo == studentRegNo).Select(p => p.StudentDepartmentCode).Single();
                    department = db.Departments.Where(c => c.DepartmentCode == departmentCode).Select(p => p.DepartmentName).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = department,
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
        public JsonResult GetCourseCode(string departmentName)// REG NO IS COMING AS PARAMETER
        {
            List<CourseStudent> allCourses = new List<CourseStudent>();

            if (departmentName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    //string departmentCode =
                    //    db.CoursesStudents.Where(p => p.StudentRegNo.Equals(departmentName))
                    //        .Select(d => d.StudentDepartmentCode)
                    //        .Single();
                    //allCourses = db.CoursesStudents.Where(a => a.CourseStudentRegNo.Equals(departmentName)).Select(s=>s.CourseStudentCourse).ToList();
                    allCourses = db.CoursesStudents.Where(a => a.CourseStudentRegNo.Equals(departmentName)).OrderBy(p=>p.CourseStudentCourse).ToList();
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
