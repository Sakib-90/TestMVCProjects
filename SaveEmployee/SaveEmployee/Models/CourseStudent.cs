using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApplication.Controllers;

namespace UniversityApplication.Models
{
    public class CourseStudent
    {
        [Required]
        [DisplayName("Student Reg. No.")]
        public string CourseStudentRegNo { get; set; }

        [Required]
        [DisplayName("Name")]
        [NotMapped]
        public string CourseStudentName { get; set; }

        [Required]
        [DisplayName("Email")]
        [NotMapped]
        public string CourseStudentEmail { get; set; }

        [Required]
        [DisplayName("Department")]
        [NotMapped]
        public string CourseStudentDepartmentCode { get; set; }

        [Required]
        [Remote("IsCourseCodeExists","CourseStudents", ErrorMessage="Course Already Taken")]
        [DisplayName("Select Course")]
        public string CourseStudentCourse { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime CourseStudentRegDate { get; set; }
        
        
        [Key]
        public int CourseStudentID { get; set; }
    }
}