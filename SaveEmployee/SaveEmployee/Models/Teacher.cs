using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Teacher
    {
        public string TeacherDesignation { get; set; }
        [DisplayName("Credit to be taken")]
        [Range(0.0, double.MaxValue,ErrorMessage = "Credit Must be a positive value")]
        public double TeacherCredit { get; set; }
        [Key]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already in use. Please try new email")]
        public string TeacherEmail { get; set; }
        public string TeacherName { get; set; }
        [DisplayName("Contact No.")]
        public string TeacherContact { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherDepartmentCode { get; set; }


    }
}