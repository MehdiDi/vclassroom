using System;
using System.Collections.Generic;
using System.Text;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Common.ViewModels
{
    public class SessionCollectionVM
    {
        public int CourseId { get; set; }
        public IList<Session> Sessions { get; set; }
    }
}
