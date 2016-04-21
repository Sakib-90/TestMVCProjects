﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Teacher : Person
    {
        public string Designation { get; set; }
        [DisplayName("Credit to be taken")]
        public int Credit { get; set; }

        [Key]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already in use. Please try new email")]
        public string Email { get; set; }
    }
}