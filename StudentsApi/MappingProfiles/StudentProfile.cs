using AutoMapper;
using Students.Domain.DTOs.Requests;
using Students.Domain.Entities;

namespace StudentsApi.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<AddStudentDto, Student>()
                .ForMember(d => d.DateOfBirth, options => options.MapFrom(s => DateTime.SpecifyKind(s.DateOfBirth, DateTimeKind.Utc)));
        }
    }
}
