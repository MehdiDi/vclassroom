using System;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Application.Models;

namespace VClassroom.Authentication.Api.Domain.Interfaces
{
    public interface IInstructorProfileService
    {
        Task Create(InstructorProfileVm instructorProfile);
        Task<InstructorProfileVm> Get(int id);
        Task<InstructorProfileVm> Update(InstructorProfileVm instructorProfile);

    }
}
