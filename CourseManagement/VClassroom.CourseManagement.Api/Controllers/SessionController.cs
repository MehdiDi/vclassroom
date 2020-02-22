using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Api.Extensions;
using VClassroom.CourseManagement.Application.Sessions.Commands;
using VClassroom.CourseManagement.Application.Sessions.Queries;

namespace VClassroom.CourseManagement.Api.Controllers
{
    [ApiController]
    [Route("/sessions")]
    public class SessionController : Controller
    {
        private readonly IMediator _mediator;
        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("")]
        public async Task<IActionResult> UpdateSessions([FromBody]UpdateSessionsCommand command)
        {
            //return 
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _mediator.Send(new GetSessionQuery { SessionId = id, userid = HttpContext.GetUserId() });
            return Ok(session);
        }
    }
}
