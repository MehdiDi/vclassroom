using System.ComponentModel.DataAnnotations.Schema;

namespace VClassroom.CourseManagement.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
