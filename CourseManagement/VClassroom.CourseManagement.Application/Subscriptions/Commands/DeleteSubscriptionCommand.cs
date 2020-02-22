using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;

namespace VClassroom.CourseManagement.Application.Subscriptions.Commands
{
    public class DeleteSubscriptionCommand : IRequest<bool>
    {
        public int CourseId { get; set; }

        public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, bool>
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger<DeleteSubscriptionCommandHandler> _logger;

            public DeleteSubscriptionCommandHandler(
                IApplicationDbContext context,
                ILogger<DeleteSubscriptionCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<bool> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
            {
                var subscription = _context.Subscriptions.FirstOrDefault(s => s.CourseId == request.CourseId);

                if (subscription == null)
                    return false;

                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
