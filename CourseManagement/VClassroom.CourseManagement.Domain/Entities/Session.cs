using System;
using VClassroom.CourseManagement.Domain.Enums;

namespace VClassroom.CourseManagement.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public SessionStatus SessionStatus { get; set; }
    }
}