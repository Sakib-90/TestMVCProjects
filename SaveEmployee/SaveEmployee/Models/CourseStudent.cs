using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class CourseStudent
    {
        [DisplayName("Student Reg. No.")]
        public string CourseStudentRegNo { get; set; }
        [DisplayName("Name")]
        public string CourseStudentName { get; set; }
        [DisplayName("Email")]
        public string CourseStudentEmail { get; set; }
        [DisplayName("Department")]
        public string CourseStudentDepartmentCode { get; set; }
        [DisplayName("Select Course")]
        public string CourseStudentCourse { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime CourseStudentRegDate { get; set; }
        [Key]
        public int CourseStudentID { get; set; }
    }
}