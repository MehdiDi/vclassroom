using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Domain.Entities;
using VClassroom.CourseManagement.Infrastructor.Presistance;

namespace VClassroom.CourseManagement.Infrastructor.Services
{
    class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Course> Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public Task<Course> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
