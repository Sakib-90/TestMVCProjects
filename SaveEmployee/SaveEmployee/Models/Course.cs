using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Course
    {
        [Key]
        [Required]
        [Remote("IsCourseCodeExists", "Courses", ErrorMessage = "Course Code already in use. Please try new code")]
        [StringLength(50, ErrorMessage = "Must be at minimum 5 characters long.", MinimumLength = 5)]
        [DisplayName("Course Code")]
        public string Code { get; set; }

        [Required]
        [Remote("IsCourseNameExists", "Courses", ErrorMessage = "Course Name already in use. Please try new Name")]
        [DisplayName("Course Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.5, 5, ErrorMessage = "Credits must be between 0.5 to 5.0")]
        [DisplayName("Course Credits"),]
        public double Credit { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Department { get; set; }
        public string Semester { get; set; }
    }
}