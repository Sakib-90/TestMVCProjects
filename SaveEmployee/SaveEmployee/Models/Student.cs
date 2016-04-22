using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversityApplication.Models
{
    public class Student
    {
        [Key]
        public string StudentRegNo { get; set; }
        public string StudentName { get; set; }
        [DisplayName("Contact No.")]
        public string StudentContact { get; set; }
        public string StudentAddress { get; set; }
        public string StudentDepartmentCode { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string StudentEmail { get; set; }
        [DataType(DataType.Date)]
        public DateTime StudeRegDate { get; set; }
    }
}