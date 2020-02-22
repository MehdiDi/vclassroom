using System;
using System.Collections.Generic;
using System.Text;
using VClassroom.CourseManagement.Application.Courses.Queries;
using VClassroom.CourseManagement.Domain.Entities;
using VClassroom.CourseManagement.Domain.Enums;

namespace VClassroom.CourseManagement.Application.Common.Mappings
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public SessionStatus SessionStatus { get; set; }
        public int CourseId { get; set; }
        public bool IsOwner { get; set; }
    }
}
