using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class CourseStudent
    {
        public string CourseStudentRegNo { get; set; }
        public string CourseStudentName { get; set; }
        public string CourseStudentEmail { get; set; }
        public string CourseStudentDepartmentCode { get; set; }
        public string CourseStudentCourse { get; set; }
        public DateTime CourseStudentRegDate { get; set; }
    }
}