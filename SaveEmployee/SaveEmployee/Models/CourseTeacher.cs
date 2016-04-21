using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class CourseTeacher
    {
        public string Department { get; set; }
        public string Teacher { get; set; }
        [DisplayName("Credit to be taken")]
        public double CreditToTake { get; set; }
        [DisplayName("Remaining Credit")]
        public double RemainingCredit { get; set; }
        [DisplayName("Course Code")]
        public string CourseCode { get; set; }
        [DisplayName("Name")]
        public string CourseName { get; set; }
        [DisplayName("Credit")]
        public double CourseCredit { get; set; }
        public int CourseTeacherID { get; set; }
    }
}