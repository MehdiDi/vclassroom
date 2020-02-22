using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Sessions.Commands
{

    public class UpdateSessionsCommand : IRequest<IDictionary<string, IList<Session>>>
    {
        public IDictionary<string, IList<Session>> Sessions { get; set; }

        public class CreateSessionCommandHandler : IRequestHandler<UpdateSessionsCommand, IDictionary<string, IList<Session>>>
        {
            private readonly IApplicationDbContext _context;
            private ILogger<CreateSessionCommandHandler> _logger;
            //private ICourseStatusWorker _courseStatusWorker;

            public CreateSessionCommandHandler(
                    IApplicationDbContext context,
                    ILogger<CreateSessionCommandHandler> logger
                    //ICourseStatusWorker courseStatusWorker
                )
            {
                _context = context;
                _logger = logger;
                //_courseStatusWorker = courseStatusWorker;
            }

            public async Task<IDictionary<string, IList<Session>>> Handle(UpdateSessionsCommand request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.Include(c => c.Sessions)
                    .Where(c => request.Sessions.Keys.Contains(c.Id.ToString())).ToListAsync();

                courses.ForEach(c => c.Sessions = request.Sessions[c.Id.ToString()]);

                await _context.SaveChangesAsync(cancellationToken);
                //await _courseStatusWorker.StopAsync(new CancellationToken());

                return request.Sessions;
            }
        }
    }
}

