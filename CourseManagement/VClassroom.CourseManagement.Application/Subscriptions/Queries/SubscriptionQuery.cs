using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Application.Courses.Queries;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Subscriptions.Queries
{
    public class SubscriptionQuery : IRequest<IList<CourseDTO>>
    {
        public string UserId { get; set; }

        public class SubscriptionQueryHandler : IRequestHandler<SubscriptionQuery, IList<CourseDTO>>
        {
            private readonly IApplicationDbContext _context;
            private IMapper _mapper;

            public SubscriptionQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IList<CourseDTO>> Handle(SubscriptionQuery request, CancellationToken cancellationToken)
            {
                var courses = await (
                        from course in _context.Courses
                        join sub in _context.Subscriptions on course.Id equals sub.CourseId
                        where sub.UserId == request.UserId
                        select course
                    ).ToListAsync();

                return _mapper.Map<IList<CourseDTO>>(courses);
            }
        }
    }
}
