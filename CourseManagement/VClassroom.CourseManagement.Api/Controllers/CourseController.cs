using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VClassroom.CourseManagement.Api.Extensions;
using VClassroom.CourseManagement.Application.Courses.Commands;
using VClassroom.CourseManagement.Application.Courses.Queries;

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

            var course = await _mediator.Send(command);
            return Created("/courses/" + course.Id, course);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand { CourseId = id };
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery]GetCoursesQuery query)
        {
            query.UserId = HttpContext.GetUserId();

            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody]UpdateCourseCommand command)
        {
            command.UserId = HttpContext.GetUserId();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<IActionResult> All([FromQuery]GetAllCoursesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
