using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class StudentResult
    {
        [Key]
        [DisplayName("Student Reg. No.")]
        public string StudentResultRegNo { get; set; }
        [DisplayName("Name")]
        public string StudentResultName { get; set; }
        [DisplayName("Email")]
        public string StudentResultEmail { get; set; }
        [DisplayName("Department")]
        public string StudentResultDepartmentCode { get; set; }
        [DisplayName("Select Course")]
        public string StudentResultCourse { get; set; }
        [DisplayName("Select Letter Grade")]
        public string StudentResultGrade { get; set; }
    }
}