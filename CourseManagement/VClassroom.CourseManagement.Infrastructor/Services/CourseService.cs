using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Domain.Entities;
using VClassroom.CourseManagement.Infrastructor.Presistance;
using VClassroom.CourseManagement.Application.Common.Extensions;
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

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Courses.FindAsync(id);
            if(entity == null)
            {
                return false;
            }
            _context.Courses.Remove(entity);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<Course> Get(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAll(string userId, int limit=10, int page=1, string sortby="")
        {
            var request = _context.Courses.Where(course => course.UserId == userId)
                .Skip(limit * page)
                .Take(limit)
                .Include(c => c.Sessions);
            if(sortby != "")
            {
                //PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(Course)).Find(sortby, true);

                return await request.OrderBy("Title").ToListAsync();
            }
            return await request.ToListAsync();
        }

        public async Task<bool> Update(Course course)
        {
            try
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return true;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
