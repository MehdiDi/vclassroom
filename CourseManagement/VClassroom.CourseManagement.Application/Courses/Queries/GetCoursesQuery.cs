using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;

namespace VClassroom.CourseManagement.Application.Courses.Queries
{
    public class GetCoursesQuery : IRequest<IEnumerable<CourseDTO>>
    {
        public string SortBy { get; set; }
        //public string[] Filters { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public string UserId { get; set; }

        public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDTO>>
        {
            private ICourseService _courseService;
            private IMapper _mapper;
            private ILogger<GetCoursesQueryHandler> _logger;

            public GetCoursesQueryHandler(ICourseService courseService, IMapper mapper, ILogger<GetCoursesQueryHandler> logger)
            {
                _courseService = courseService;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<IEnumerable<CourseDTO>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
            {
                var courses = await _courseService.GetAll(request.UserId, limit:request.Limit, request.Page, sortby:request.SortBy);
                return _mapper.Map<IEnumerable<CourseDTO>>(courses);
            }
        }
    }
}
