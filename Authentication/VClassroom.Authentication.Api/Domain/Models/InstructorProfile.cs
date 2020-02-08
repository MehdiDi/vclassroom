using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VClassroom.Authentication.Api.Domain.Models
{
    public class InstructorProfile
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
