using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Data;
using VClassroom.Authentication.Api.Domain.Interfaces;
using VClassroom.Authentication.Api.Domain.Models;
using VClassroom.Authentication.Api.Domain.Repositories;
using VClassroom.Authentication.Api.Services;

namespace VClassroom.Authentication.Api.Infra.IoC
{
    public class ServiceRegistor
    {

        public ServiceRegistor()
        {
        }
        public static void Register(IServiceCollection serviceProvider)
        {
            ConfigureIdentity(serviceProvider);

            // Services
            serviceProvider.AddTransient<IInstructorProfileService, InstructorProfileService>();

            //Domain 
            serviceProvider.AddTransient<IInstructorProfileRepository, InstructorProfileRepository>();
        }

        private static void ConfigureIdentity(IServiceCollection serviceProvider)
        {
            
            serviceProvider.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
           
        }
    }
}
