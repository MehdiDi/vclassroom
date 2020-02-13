using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VClassroom.CourseManagement.Application.Courses.Queries;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Common.Mappings
{
    class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<Course, CourseDTO>()
                .ForMember(
                    dest => dest.Sessions,
                    opt => opt.MapFrom(src => src.Sessions)
                );
            CreateMap<CourseDTO, Course>();
        }
    }
}
