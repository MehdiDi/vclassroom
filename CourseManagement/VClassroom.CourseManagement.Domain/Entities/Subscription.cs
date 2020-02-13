using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VClassroom.CourseManagement.Domain.Enums;

namespace VClassroom.CourseManagement.Domain.Entities
{
    class Subscription
    {
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
