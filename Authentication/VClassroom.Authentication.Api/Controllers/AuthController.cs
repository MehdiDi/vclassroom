using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Application.Models;
using VClassroom.Authentication.Api.Domain.Models;

namespace VClassroom.Authentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthController(UserManager<ApplicationUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = configuration;
        }
        [HttpGet("data")]
        public IActionResult data()
        {
            return Ok("Data");
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVm user)
        {

            var userRes = await _userManager.FindByNameAsync(user.Email);

            if(userRes != null)
            {
                return Unauthorized("Email already registered");
            }

            var userModel = _mapper.Map<ApplicationUser>(user);
            var result = await _userManager.CreateAsync(userModel, user.Password);

            if(!result.Succeeded)
            {
                return Unauthorized(result.Errors);
            }

            var token = GenerateToken(userModel);


            return Ok(new
            {
                token
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel user)
        {
            var res = await _userManager.FindByNameAsync(user.UserName);
            if (res == null || !await _userManager.CheckPasswordAsync(res, user.Password))
            {
                return Unauthorized("Combination Username and password invalid");
            }
            return Ok(
                new
                {
                    token = GenerateToken(res)
                });
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userName", user.UserName),
                new Claim("email", user.Email),
                new Claim("UserType", "registered")
            };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
