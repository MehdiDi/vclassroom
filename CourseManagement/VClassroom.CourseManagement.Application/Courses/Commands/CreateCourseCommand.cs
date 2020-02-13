using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Application.Courses.Queries;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Courses.Commands
{
    public partial class CreateCourseCommand : IRequest<CourseDTO>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Session> Sessions { get; set; }
        public string UserId { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseDTO>
        {
            private readonly ICourseService _courseService;
            private ILogger<CreateCourseCommand> _logger;
            private readonly IMapper _mapper;

            public CreateCourseCommandHandler(ICourseService courseService, ILogger<CreateCourseCommand> logger, IMapper mapper)
            {
                _courseService = courseService;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<CourseDTO> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("New course created by user {0}", request.UserId);

                var entity = new Course
                {
                    Description = request.Description,
                    Title = request.Title,
                    Sessions = request.Sessions,
                    UserId = request.UserId
                };

                await _courseService.Create(entity);

                return _mapper.Map<CourseDTO>(entity);
            }
        }
    }
}
