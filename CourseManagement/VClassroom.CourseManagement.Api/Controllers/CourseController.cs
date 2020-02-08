using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Api.Extensions;
using VClassroom.CourseManagement.Application.Courses.Commands;

namespace VClassroom.CourseManagement.Api.Controllers
{
    [ApiController]
    [Route("/courses")]
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateCourseCommand command)
        {
            var userId = HttpContext.GetUserId();
            command.UserId = userId;

            var result = await _mediator.Send(command);
            return Created("/courses/" + result, command);
        }
    }
}
