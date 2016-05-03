using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class StudentResultsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        ResultManager resultManager = new ResultManager();

        public ActionResult SaveResult()
        {
            GenerateDropDownValue();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveResult([Bind(Include = "StudentResultRegNo,StudentResultName,StudentResultEmail,StudentResultDepartmentCode,StudentResultCourse,StudentResultGrade")] StudentResult studentResult)
        {
            GenerateDropDownValue();

           if (ModelState.IsValid)
            {
                db.StudentResults.Add(studentResult);
                db.SaveChanges();
                return RedirectToAction("SaveResult");
            }

            return View(studentResult);
        }

        private void GenerateDropDownValue()
        {
            List<Student> allRegisteredStudents = new List<Student>();
            List<SelectListItem> students = new List<SelectListItem>();

            List<CourseStudent> allCourses = new List<CourseStudent>();

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
            ViewBag.Students = students;

            ViewBag.CourseCode = new SelectList(allCourses, "CourseStudentCourse", "CourseStudentCourse");

            ViewBag.StudentName = "";
            ViewBag.StudentEmail = "";
            ViewBag.StudentDepartment = "";

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
        public JsonResult GetCourseCode(string departmentName)
        {
            List<CourseStudent> allCourses = new List<CourseStudent>();

            if (departmentName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
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
