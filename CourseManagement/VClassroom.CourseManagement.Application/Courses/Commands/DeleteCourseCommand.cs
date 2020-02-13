using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;

namespace VClassroom.CourseManagement.Application.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int CourseId { get; set; }

        public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
        {
            private readonly ICourseService _courseService;

            public DeleteCourseCommandHandler(ICourseService courseService)
            {
                _courseService = courseService;
            }

            public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
                var result = await _courseService.Delete(request.CourseId);
                return result;
            }
        }
    }
}
