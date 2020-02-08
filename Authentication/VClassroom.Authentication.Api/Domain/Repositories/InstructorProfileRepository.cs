using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Data;
using VClassroom.Authentication.Api.Domain.Interfaces;
using VClassroom.Authentication.Api.Domain.Models;

namespace VClassroom.Authentication.Api.Domain.Repositories
{
    public class InstructorProfileRepository : IInstructorProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public InstructorProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<InstructorProfile> Add(InstructorProfile instructorProfile)
        {
            var instructor = await _context.AddAsync(instructorProfile);
            await SaveChanges();
            return instructor.Entity;
        }

        public async Task Delete(InstructorProfile instructorProfile)
        {
            _context.Remove(instructorProfile);
            await SaveChanges();
        }

        public async Task<InstructorProfile> Get(int id)
        {
            return await _context.InstructorProfiles
                .Include(p => p.ApplicationUser).FirstAsync(p => p.Id == id);
        }

        public async Task<InstructorProfile> Update(InstructorProfile instructorProfile)
        {
            var value = _context.InstructorProfiles.Update(instructorProfile);
            await SaveChanges();
            return value.Entity;

        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
