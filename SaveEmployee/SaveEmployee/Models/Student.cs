using System;

namespace UniversityApplication.Models
{
    public class Student : Person
    {
        public string RegNo { get; set; }
        public DateTime Date { get; set; }
    }
}