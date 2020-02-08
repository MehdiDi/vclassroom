using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VClassroom.Authentication.Api.Application.Models
{
    public class RegisterVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
