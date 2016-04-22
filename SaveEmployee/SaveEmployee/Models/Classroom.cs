﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class Classroom
    {
        public string ClassRoomDepartmentCode { get; set; }
        public string ClassRoomCourseID { get; set; }
        public string ClassRoomRoomNo { get; set; }
        public string ClassRoomWeekDay { get; set; }
        public TimeSpan ClassRoomStartsAt { get; set; }
        public TimeSpan ClassRoomEndssAt { get; set; }
    }
}