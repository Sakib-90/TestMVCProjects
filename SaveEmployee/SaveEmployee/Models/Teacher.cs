using System.ComponentModel.DataAnnotations;

namespace UniversityApplication.Models
{
    public class Teacher : Person
    {
        public string Designation { get; set; }
        public int Credit { get; set; }
    }
}