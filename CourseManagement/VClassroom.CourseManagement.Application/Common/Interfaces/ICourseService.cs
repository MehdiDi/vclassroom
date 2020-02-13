using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Common.Interfaces
{
    public interface ICourseService
    {
        Task<Course> Create(Course course);
        Task<IEnumerable<Course>> GetAll(string userId, int limit = 10, int page = 1, string sortby = "");
        Task<Course> Get(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(Course course);
    }
}
