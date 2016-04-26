using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Student
    {
        [Key]
        public string StudentRegNo { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
        [DisplayName("Contact No.")]
        public string StudentContact { get; set; }
        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        public string StudentAddress { get; set; }
        public string StudentDepartmentCode { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsEmailExists", "Students", ErrorMessage = "Email already in use. Please try new email")]
        [DisplayName("Email")]
        public string StudentEmail { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime StudeRegDate { get; set; }
    }
}