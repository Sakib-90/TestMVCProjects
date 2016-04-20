using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversityApplication.Models
{
    public class Teacher : Person
    {
        public string Designation { get; set; }
        [DisplayName("Credit to be taken")]
        public int Credit { get; set; }
    }
}