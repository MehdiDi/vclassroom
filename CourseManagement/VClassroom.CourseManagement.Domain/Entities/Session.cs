using System;
using System.ComponentModel.DataAnnotations.Schema;
using VClassroom.CourseManagement.Domain.Enums;

namespace VClassroom.CourseManagement.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public SessionStatus SessionStatus { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        //public Course Course { get; set; }
    }
}