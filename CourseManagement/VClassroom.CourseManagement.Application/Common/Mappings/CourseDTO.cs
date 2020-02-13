using System;
using System.Collections.Generic;
using System.Text;
using VClassroom.CourseManagement.Application.Common.Mappings;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Courses.Queries
{
    public class CourseDTO : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<SessionDTO> Sessions { get; set; }
    }
}
