using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversityApplication.Models
{
    public class Person
    {
        public string Name { get; set; }
        [Key]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DisplayName("Contact No.")]
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}