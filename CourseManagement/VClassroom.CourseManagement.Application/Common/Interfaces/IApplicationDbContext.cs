using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Session> Sessions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
