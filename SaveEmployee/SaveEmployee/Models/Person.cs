using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Person
    {
        public string Name { get; set; }
        
        [DisplayName("Contact No.")]
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}