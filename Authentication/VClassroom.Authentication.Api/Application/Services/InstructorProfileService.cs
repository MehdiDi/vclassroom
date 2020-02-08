using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Application.Models;
using VClassroom.Authentication.Api.Domain.Interfaces;
using VClassroom.Authentication.Api.Domain.Models;

namespace VClassroom.Authentication.Api.Services
{
    public class InstructorProfileService : IInstructorProfileService
    {
        private readonly IInstructorProfileRepository _repository;

        private readonly IMapper _mapper;
        public InstructorProfileService(IInstructorProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(InstructorProfileVm instructorProfile)
        {
            await _repository.Add(_mapper.Map<InstructorProfile>(instructorProfile));
        }

        public async Task<InstructorProfileVm> Get(int id)
        {
            var value = await _repository.Get(id);
            return _mapper.Map<InstructorProfileVm>(value);
        }

        public async Task<InstructorProfileVm> Update(InstructorProfileVm instructorProfile)
        {
            var value = await _repository.Update(_mapper.Map<InstructorProfile>(instructorProfile));
            return _mapper.Map<InstructorProfileVm>(value);
        }
    }
}
