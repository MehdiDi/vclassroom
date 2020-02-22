using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace VClassroom.CourseManagement.Application.Common.Interfaces
{
    public interface ICourseStatusWorker : IHostedService
    {
        //public Task StartAsync(CancellationToken cancellationToken);
        //public Task StopAsync(CancellationToken cancellationToken);
    }
}
