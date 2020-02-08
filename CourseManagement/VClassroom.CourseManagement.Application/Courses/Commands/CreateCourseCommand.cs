using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Courses.Commands
{
    public class CreateCourseCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Session> Sessions { get; set; }
        public string UserId { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly ICourseService _courseService;
            private ILogger<CreateCourseCommand> _logger;

            public CreateCourseCommandHandler(ICourseService courseService, ILogger<CreateCourseCommand> logger)
            {
                _courseService = courseService;
                _logger = logger;
            }

            public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("New course created by user {0}", request.Id);

                var entity = new Course
                {
                    Description = request.Description,
                    Title = request.Title,
                    Sessions = request.Sessions,
                    UserId = request.UserId
                };
                await _courseService.Create(entity);
                
                return entity.Id;
            }
        }
    }
}
