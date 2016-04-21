using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApplication.BLL;

namespace UniversityApplication.Controllers
{
    public class CourseTeacherController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();

        TeacherManager teacherManager = new TeacherManager();

        CourseManager courseManager = new CourseManager();

        // GET: CourseTeacher
        public ActionResult CourseTeacher()
        {
            GenerateDropDownValue();
            return View();
        }

        private void GenerateDropDownValue()
        {
            var departments = departmentManager.GetDepartments();

            List<SelectListItem> departmentList = new List<SelectListItem>();

            foreach (var department in departments)
            {
                departmentList.Add(

                    new SelectListItem()
                    {
                        Value = department.Name,
                        Text = department.Name
                    }
                    );
            }

            ViewBag.Departments = departmentList;

            var teachersList = teacherManager.GetTeachers();

            List<SelectListItem> teacherNameList = new List<SelectListItem>();

            foreach (var teacher in teachersList)
            {
                teacherNameList.Add(

                    new SelectListItem()
                    {
                        Value = teacher.Name,
                        Text = teacher.Name
                    }
                    );
            }

            ViewBag.TeachersName = teacherNameList;

            //List<SelectListItem> teacherCreditList = new List<SelectListItem>();

            //foreach (var teacher in teachersList)
            //{
            //    teacherCreditList.Add(

            //        new SelectListItem()
            //        {
            //            Value = teacher.Credit.ToString(),
            //            Text = teacher.Credit.ToString()
            //        }
            //        );
            //}

            //ViewBag.TeachersCredit = teacherCreditList; 

            var courseList = courseManager.GetCourses();

            List<SelectListItem> courseCodeList = new List<SelectListItem>();

            foreach (var course in courseList)
            {
                courseCodeList.Add(

                    new SelectListItem()
                    {
                        Value = course.Code,
                        Text = course.Code
                    }
                    );
            }

            ViewBag.CourseCode = courseCodeList;
        }
    }
}