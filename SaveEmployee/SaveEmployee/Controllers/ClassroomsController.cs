using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaveEmployee.BLL;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace SaveEmployee.Controllers
{
    public class ClassroomsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        DepartmentManager departmentManager = new DepartmentManager();
        RoomManager roomManager = new RoomManager();

        // GET: Classrooms
       
        public ActionResult AllocateClassRoom()
        {
            List<Department> allDepartments = new List<Department>();
            List<Course> allCourses = new List<Course>();
            
            GenerateDropDownValue();
            
            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }

            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName");
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode");

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllocateClassRoom([Bind(Include = "ClassRoomRoomNo,ClassRoomDepartmentCode,ClassRoomCourseID,ClassRoomWeekDay,ClassRoomStartsAt,ClassRoomEndssAt")] Classroom classroom)
        {
            List<Department> allDepartments = new List<Department>();
            List<Course> allCourses = new List<Course>();

            GenerateDropDownValue();

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();

                if (classroom != null)
                {


                    if (classroom.ClassRoomCourseCode != null)
                    {
                        allCourses =
                             db.Courses.Where(a => a.CourseCode.Equals(classroom.ClassRoomCourseCode))
                                 .OrderBy(a => a.CourseName)
                                 .ToList();
                    }

                }
            }

            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName", classroom.ClassRoomDepartmentCode);
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode", classroom.ClassRoomCourseCode);

            if (ModelState.IsValid)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    //courseTeacher.CourseTeacherCourseCredit = db.Courses.Where(c => c.CourseCode == courseTeacher.CourseTeacherCourseCode).Select(p => (double?)p.CourseCredit).Single();


                    db.Classrooms.Add(classroom);
                    db.SaveChanges();
                    ModelState.Clear();
                    classroom = null;
                }
            }
            return View(classroom);
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

        private void GenerateDropDownValue()
        {
            var rooms = roomManager.GetRooms();

            List<SelectListItem> roomList = new List<SelectListItem>();

            foreach (var room in rooms)
            {
                roomList.Add(

                    new SelectListItem()
                    {
                        Value = room,
                        Text = room
                    }
                    );
            }

            ViewBag.Room = roomList;

            List<SelectListItem> weekdays = new List<SelectListItem>
            {
                //new SelectListItem {Text = "--Select--", Value = ""},
                new SelectListItem {Text = "Saturday", Value = "Saturday"},
                new SelectListItem {Text = "Sunday", Value = "Sunday"},
                new SelectListItem {Text = "Monday", Value = "Monday"},
                new SelectListItem {Text = "Tuesday", Value = "Tuesday"},
                new SelectListItem {Text = "Wednesday", Value = "Wednesday"},
                new SelectListItem {Text = "Thursday", Value = "Thursday"},
                new SelectListItem {Text = "Friday", Value = "Friday"}
            };

            ViewBag.Weekday = weekdays;
            
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
