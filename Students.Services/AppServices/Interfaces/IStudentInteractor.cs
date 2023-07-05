using Students.Domain.DTOs.Requests;
using Students.Domain.DTOs.Responses;
using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.AppServices.Interfaces
{
    public interface IStudentInteractor
    {
        Task<ApiResponse<IEnumerable<Student>?>> GetStudents();
        Task<ApiResponse<Student?>> AddStudent(AddStudentDto Dto);
    }
}
