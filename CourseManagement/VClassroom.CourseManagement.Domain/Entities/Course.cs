using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VClassroom.CourseManagement.Domain.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Session> Sessions { get; set; }
        [Required(ErrorMessage = "User is required")]
        public string UserId { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
