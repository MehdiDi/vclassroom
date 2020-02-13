using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace VClassroom.CourseManagement.Infrastructor.Presistance
{
    public class MigrationHandler
    {
        public static void MigrateOnStartup(IServiceProvider provider)
        {
            using (var scope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>().Database;
                if (db.GetPendingMigrations().Any())
                {
                    db.Migrate();
                }
            }
        }
    }
}
