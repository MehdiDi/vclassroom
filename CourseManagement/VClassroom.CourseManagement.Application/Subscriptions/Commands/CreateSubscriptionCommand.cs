using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Application.Common.Interfaces;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Subscriptions.Commands
{
    public class CreateSubscriptionCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public string UserId { get; set; }

        public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, bool>
        {
            private readonly IApplicationDbContext _context;
            private ILogger<CreateSubscriptionCommandHandler> _logger;

            public CreateSubscriptionCommandHandler(IApplicationDbContext applicationDbContext, ILogger<CreateSubscriptionCommandHandler> logger)
            {
                _context = applicationDbContext;
                _logger = logger;
            }

            public async Task<bool> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
            {
                _context.Subscriptions.Add(
                    new Subscription
                    {
                        CourseId = request.CourseId,
                        UserId = request.UserId
                    });

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
