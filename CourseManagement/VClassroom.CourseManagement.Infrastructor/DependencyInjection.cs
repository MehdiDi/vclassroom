using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Infrastructor.Presistance;
using VClassroom.CourseManagement.Infrastructor.Services;

namespace VClassroom.CourseManagement.Infrastructor
{
    public static class DependencyInjection
    {
        public static void AddInfrastructor(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("VCCourseManagement"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddLogging();
        }
    }
}
