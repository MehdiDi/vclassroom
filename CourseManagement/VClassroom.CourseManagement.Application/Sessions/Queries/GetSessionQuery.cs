using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Application.Common.Mappings;
using VClassroom.CourseManagement.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VClassroom.CourseManagement.Application.Sessions.Queries
{
    public class GetSessionQuery : IRequest<SessionDTO>
    {
        public int SessionId { get; set; }
        public string userid { get; set; }

        public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, SessionDTO>
        {
            private readonly IApplicationDbContext _context;
            private IMapper _mapper;
            private ILogger<GetSessionQueryHandler> _logger;

            public GetSessionQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetSessionQueryHandler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<SessionDTO> Handle(GetSessionQuery request, CancellationToken cancellationToken)
            {
                var session = await (from s in _context.Sessions
                               join c in _context.Courses on s.CourseId equals c.Id
                               where s.Id == request.SessionId
                               select new
                               {
                                   isOwner = (c.UserId == request.userid),
                                   Session = s
                               }).FirstAsync();

                var sessionDto = _mapper.Map<SessionDTO>(session.Session);
                sessionDto.IsOwner = session.isOwner;

                return sessionDto;
            }
        }
    }
}
