using System;

namespace VClassroom.CourseManagement.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}