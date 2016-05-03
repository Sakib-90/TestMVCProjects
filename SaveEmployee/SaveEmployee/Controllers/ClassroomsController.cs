using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class ClassroomsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        RoomManager roomManager = new RoomManager();
      
        public ActionResult AllocateClassRoom()
        {
            GenerateDropDownValue();

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllocateClassRoom([Bind(Include = "ClassRoomRoomNo,ClassRoomDepartmentCode,ClassRoomCourseID,ClassRoomWeekDay,ClassRoomStartsAt,ClassRoomEndssAt,ClassRoomCourseCode")] Classroom classroom)
        {
            GenerateDropDownValue();
            
            if (ModelState.IsValid)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    
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
            List<Department> allDepartments = new List<Department>();
            List<SelectListItem> departments = new List<SelectListItem>();
            List<Course> allCourses = new List<Course>();

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }

            foreach (var department in allDepartments)
            {
                departments.Add(

                    new SelectListItem()
                    {
                        Value = department.DepartmentCode,
                        Text = department.DepartmentName
                    }
                    );
            }

            ViewBag.Departments = departments;
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode");
            
            
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
