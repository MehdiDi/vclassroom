using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VClassroom.Authentication.Api.Application.Models
{
    public class InstructorProfileVm
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public string UserId { get; set; }
    }
}
