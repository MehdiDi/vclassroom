using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Common.Interfaces
{
    public interface ICourseService
    {
        Task<Course> Create(Course course);
        Task<IEnumerable<Course>> GetAll();
        Task<Course> Get(int id);
    }
}
