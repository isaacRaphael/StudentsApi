using AutoMapper;
using Students.Domain.DTOs.Requests;
using Students.Domain.Entities;

namespace StudentsApi.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<AddTeacherDto, Teacher>()
                .ForMember(d => d.DateOfBirth, options => options.MapFrom(s => DateTime.SpecifyKind(s.DateOfBirth, DateTimeKind.Utc)));
        }
    }
}
