using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;

namespace UniversityApplication.Models
{

    public class Department
    {
        [Key]
        [Required]
        [Remote("IsDepartmentCodeExists", "Departments", ErrorMessage = "Department Code already in use. Please try new code")]
        [StringLength(7, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DisplayName("Department Code")]
        public string Code { get; set; }
        
        [Required]
        [Remote("IsDepartmentNameExists", "Departments", ErrorMessage = "Department Name already in use. Please try new name")]
        [DisplayName("Department Name")]
        public string Name { get; set; }
    }
}