using System.ComponentModel.DataAnnotations;

namespace SaveEmployee.Models
{
    public class Department
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}