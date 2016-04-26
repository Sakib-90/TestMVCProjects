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

namespace SaveEmployee.Controllers
{
    public class CourseStudentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        // GET: CourseStudents/Create
        public ActionResult StudentToCourse()
        {
            List<Student> allRegisteredStudents = new List<Student>();
            using (ApplicationContext db = new ApplicationContext())
            {
                allRegisteredStudents = db.Students.OrderBy(a=>a.StudentRegNo).ToList();
            }
            ViewBag.Students = new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentToCourse([Bind(Include = "CourseStudentID,CourseStudentRegNo,CourseStudentName,CourseStudentEmail,CourseStudentDepartmentCode,CourseStudentCourse,CourseStudentRegDate")] CourseStudent courseStudent)
        {
            List<Student> allRegisteredStudents = new List<Student>();
            using (ApplicationContext db = new ApplicationContext())
            {
                allRegisteredStudents = db.Students.OrderBy(a => a.StudentRegNo).ToList();
            }
            ViewBag.Students = new SelectList(allRegisteredStudents, "StudentRegNo", "StudentRegNo", courseStudent.CourseStudentRegNo);

            if (ModelState.IsValid)
            {
                db.CoursesStudents.Add(courseStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseStudent);
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
