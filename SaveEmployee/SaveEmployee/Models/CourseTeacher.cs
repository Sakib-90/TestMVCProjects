﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class CourseTeacher
    {
        public string CourseTeacherDepartmentCode { get; set; }
        public string CourseTeacherEmail { get; set; }
        [DisplayName("Credit to be taken")]
        public double CourseTeacherCreditToTake { get; set; }
        [DisplayName("Remaining Credit")]
        public double CourseTeacherRemainingCredit { get; set; }
        [DisplayName("Code")]
        public string CourseTeacherCourseCode { get; set; }
        [DisplayName("Name")]
        public string CourseTeacherCourseName { get; set; }
        [DisplayName("Credit")]
        public double CourseTeacherCourseCredit { get; set; }
        public int CourseTeacherID { get; set; }
    }
}