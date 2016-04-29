using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Teacher
    {
        [DisplayName("Designation")]
        public string TeacherDesignation { get; set; }
        [DisplayName("Credit to be taken")]
        [Range(0.0, double.MaxValue,ErrorMessage = "Credit Must be a positive value")]
        public double TeacherCredit { get; set; }
        [Key]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already in use. Please try new email")]
        [DisplayName("Email")]
        public string TeacherEmail { get; set; }
        [DisplayName("Name")]
        public string TeacherName { get; set; }
        [DisplayName("Contact No.")]
        public string TeacherContact { get; set; }
        [DisplayName("Address")]
        public string TeacherAddress { get; set; }
        [DisplayName("Department")]
        public string TeacherDepartmentCode { get; set; }


    }
}