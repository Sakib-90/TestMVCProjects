using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class Classroom
    {
        [DisplayName("Department")]
        public string ClassRoomDepartmentCode { get; set; }
        [DisplayName("Course")]
        public string ClassRoomCourseCode { get; set; }
        [DisplayName("Room No")]
        public string ClassRoomRoomNo { get; set; }
        [DisplayName("Day")]
        public string ClassRoomWeekDay { get; set; }
        [DisplayName("From")]
        [DataType(DataType.Time)]
        public TimeSpan ClassRoomStartsAt { get; set; }
        [DisplayName("To")]
        [DataType(DataType.Time)]
        public TimeSpan ClassRoomEndssAt { get; set; }
        public int ClassroomId { get; set; }
    }
}