using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VClassroom.Authentication.Api.Application.Models;
using VClassroom.Authentication.Api.Domain.Interfaces;

namespace VClassroom.Authentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly IInstructorProfileService _instructorProfileService;

        public ProfileController(IInstructorProfileService instructorProfileService)
        {
            _instructorProfileService = instructorProfileService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await _instructorProfileService.Get(id);
            return Ok(
                profile
            );
        }
        [HttpPut("put")]
        public async Task<IActionResult> Update([FromBody]InstructorProfileVm instructor)
        {
            var value = await _instructorProfileService.Update(instructor);
            return Ok(value);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]InstructorProfileVm instructor)
        {
             await _instructorProfileService.Create(instructor);
            return Ok("Profile Created");
        }
    }
}