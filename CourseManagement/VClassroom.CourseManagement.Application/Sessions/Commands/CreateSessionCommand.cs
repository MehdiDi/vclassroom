using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Application.Common.Mappings;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Sessions.Commands
{
    public class UpdateSessionsCommand : IRequest<bool>
    {
        public IEnumerable<SessionDTO> Sessions { get; set; }
        public int CourseId { get; set; }

        public class CreateSessionCommandHandler : IRequestHandler<UpdateSessionsCommand, bool>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateSessionCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateSessionsCommand request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses.FindAsync(request.CourseId);
                course.Sessions = _mapper.Map<IList<Session>>(request.Sessions);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
