namespace SaveEmployee.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
    }
}