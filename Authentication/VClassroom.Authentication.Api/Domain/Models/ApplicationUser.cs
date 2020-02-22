using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VClassroom.Authentication.Api.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MinLength(6, ErrorMessage ="Address must be valid")]
        public string Address { get; set; }
        public int uId { get; set; }

    }
}
