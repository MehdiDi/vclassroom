using System;
using System.Collections.Generic;
using System.Text;
using VClassroom.CourseManagement.Domain.Enums;

namespace VClassroom.CourseManagement.Application.Common.Mappings
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public SessionStatus SessionStatus { get; set; }
    }
}
