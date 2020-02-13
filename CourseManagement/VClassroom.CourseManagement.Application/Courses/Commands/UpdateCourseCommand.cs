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
    public class UpdateCourseCommand : IRequest<CourseDTO>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Session> Sessions { get; set; }
        public string UserId { get; set; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseDTO>
        {
            private readonly ICourseService _courseService;
            private IMapper _mapper;
            private ILogger<UpdateCourseCommandHandler> _logger;

            public UpdateCourseCommandHandler(ICourseService courseService, IMapper mapper, ILogger<UpdateCourseCommandHandler> logger)
            {
                _courseService = courseService;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<CourseDTO> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                var entity = new Course
                {
                    Id = request.Id,
                    Description = request.Description,
                    Title = request.Title,
                    Sessions = request.Sessions,
                    UserId = request.UserId
                };
                _logger.LogInformation("Updating course {0} {1} {2} {3}", entity.Id, 
                    entity.Description, entity.Title, entity.UserId
                );
                var result = await _courseService.Update(entity);
                return _mapper.Map<CourseDTO>(entity);
            }
        }
    }
}
