using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Domain.Models;

namespace VClassroom.Authentication.Api.Domain.Interfaces
{
    public interface IInstructorProfileRepository
    {
        Task<InstructorProfile> Add(InstructorProfile instructorProfile);
        Task Delete(InstructorProfile instructorProfile);
        Task<InstructorProfile> Get(int id);
        Task<InstructorProfile> Update(InstructorProfile instructorProfile);
    }
}
