using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;

namespace VClassroom.CourseManagement.Application.Courses.Queries
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<CourseDTO>>
    {
        
        public class GetAllCoursesQueryHandler: IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDTO>>
        {
            private IMapper _mapper;
            private ILogger<GetAllCoursesQuery> _logger;
            private IApplicationDbContext _context;


            public GetAllCoursesQueryHandler(IMapper mapper, ILogger<GetAllCoursesQuery> logger, IApplicationDbContext context)
            {
                _mapper = mapper;
                _logger = logger;
                _context = context;
            }
            public async Task<IEnumerable<CourseDTO>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.ToListAsync();

                return _mapper.Map<IEnumerable<CourseDTO>>(courses);
            }
        }

    }
}
