using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class CourseTeacher
    {
        [DisplayName("Department")]
        public string CourseTeacherDepartmentCode { get; set; }
        [DisplayName("Teacher")]
        public string CourseTeacherEmail { get; set; }
        [DisplayName("Credit to be taken")]
        [NotMapped]
        public double CourseTeacherCreditToTake { get; set; }
        [DisplayName("Remaining Credit")]
        [NotMapped]
        public double? CourseTeacherRemainingCredit { get; set; }
        [DisplayName("Code")]
        [Remote("IsCodeExists", "CourseTeacher", ErrorMessage = "Course already assigned")]
        [NotMapped]
        public string CourseTeacherCourseCode { get; set; }
        [DisplayName("Name")]
        [NotMapped]
        public string CourseTeacherCourseName { get; set; }
        [DisplayName("Credit")]
        [NotMapped]
        public double? CourseTeacherCourseCredit { get; set; }
        
        [Key]
        public int CourseTeacherID { get; set; }
    }
}