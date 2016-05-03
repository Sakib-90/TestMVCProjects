﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class CourseStudentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        // GET: CourseStudents/Create
        public ActionResult StudentToCourse()
        {

            GenerateDropDownValue();
            //List<Student> allRegisteredStudents = new List<Student>();
            //List<Course> allCourses = new List<Course>();

            //string studentName = "";
            //string studentEmail = "";
            //string studentDepartment = "";

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    allRegisteredStudents = db.Students.OrderBy(a=>a.StudentRegNo).ToList();
            //}
            //ViewBag.Students = new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo");
            //ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseName");
            //ViewBag.StudentName = studentName;
            //ViewBag.StudentEmail = studentEmail;
            //ViewBag.StudentDepartment = studentDepartment;

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentToCourse([Bind(Include = "CourseStudentID,CourseStudentRegNo,CourseStudentName,CourseStudentEmail,CourseStudentDepartmentCode,CourseStudentCourse,CourseStudentRegDate")] CourseStudent courseStudent)
        {
            GenerateDropDownValue();
            //List<Student> allRegisteredStudents = new List<Student>();
            //List<Course> allCourses = new List<Course>();
            //string studentName = "";
            //string studentEmail = "";
            //string studentDepartment = "";

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    allRegisteredStudents = db.Students.OrderBy(a => a.StudentRegNo).ToList();
            //}
            //ViewBag.Students = new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo", courseStudent.CourseStudentRegNo);
            //ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseName",courseStudent.CourseStudentCourse);
            //ViewBag.StudentName = studentName;
            //ViewBag.StudentEmail = studentEmail;
            //ViewBag.StudentDepartment = studentDepartment;

            if (ModelState.IsValid)
            {
                db.CoursesStudents.Add(courseStudent);
                db.SaveChanges();
                ModelState.Clear();
                //return RedirectToAction("StudentToCourse");
                return View();
            }
            ModelState.Clear();
            //return RedirectToAction("StudentToCourse");
            return View();

            //return View(courseStudent);
        }

        private void GenerateDropDownValue()
        {
            List<SelectListItem> students = new List<SelectListItem>();
            List<Student> allRegisteredStudents = new List<Student>();
            List<SelectListItem> courses = new List<SelectListItem>();

            List<Course> allCourses = new List<Course>();
            string studentName = "";
            string studentEmail = "";
            string studentDepartment = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                allRegisteredStudents = db.Students.OrderBy(a => a.StudentRegNo).ToList();
            }

            foreach (var student in allRegisteredStudents)
            {
                students.Add(

                    new SelectListItem()
                    {
                        Value = student.StudentRegNo,
                        Text = student.StudentRegNo
                    }
                    );
            }


            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    allCourses = db.Courses.OrderBy(a => a.CourseCode).ToList();
            //}

            //foreach (var course in allCourses)
            //{
            //    courses.Add(

            //        new SelectListItem()
            //        {
            //            //Value = course.CourseCode,
            //            //Text = course.CourseName

            //            Value = "",
            //            Text = ""
            //        }
            //        );
            //}


            ViewBag.Students = students;//new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo", courseStudent.CourseStudentRegNo);
           // ViewBag.CourseCode = courses;//new SelectList(allCourses, "CourseCode", "CourseName", courseStudent.CourseStudentCourse);

            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseName");
            ViewBag.StudentName = studentName;
            ViewBag.StudentEmail = studentEmail;
            ViewBag.StudentDepartment = studentDepartment;
        }
        public JsonResult IsCourseNameExists(string CourseStudentCourse, string CourseStudentRegNo)
        {
            //return Json(!db.CoursesStudents.Any(x => x.CourseStudentCourse == CourseStudentCourse ), JsonRequestBehavior.AllowGet);
            return Json(!db.CoursesStudents.Any(x => x.CourseStudentCourse == CourseStudentCourse && x.CourseStudentRegNo == CourseStudentRegNo), JsonRequestBehavior.AllowGet);
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

        public JsonResult GetCourseCode(string departmentName)
        {
            List<Course> allCourses = new List<Course>();

            if (departmentName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    string departmentCode =
                        db.Students.Where(p => p.StudentRegNo.Equals(departmentName))
                            .Select(d => d.StudentDepartmentCode)
                            .Single();
                    allCourses = db.Courses.Where(a => a.CourseDepartmentCode.Equals(departmentCode)).OrderBy(a => a.CourseName).ToList();
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
