using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Api.Extensions;
using VClassroom.CourseManagement.Application.Subscriptions.Commands;
using VClassroom.CourseManagement.Application.Subscriptions.Queries;

namespace VClassroom.CourseManagement.Api.Controllers
{
    [ApiController]
    [Route("/subscriptions")]
    public class SubscriptionController : Controller
    {
        private IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(CreateSubscriptionCommand command)
        {
            command.UserId = HttpContext.GetUserId();

            await _mediator.Send(command);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Create(int id)
        {
            var command = new DeleteSubscriptionCommand
            {
                CourseId = id
            };

            await _mediator.Send(command);

            return Ok();
        }
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var subscriptions = await _mediator.Send(new SubscriptionQuery
            {
                UserId = HttpContext.GetUserId()
            });

            return Ok(new
            {
                subscriptions
            });
        }
    }
}
