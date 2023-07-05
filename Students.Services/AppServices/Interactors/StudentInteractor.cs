using AutoMapper;
using Students.Data.Interfaces;
using Students.Domain.DTOs.Requests;
using Students.Domain.DTOs.Responses;
using Students.Domain.Entities;
using Students.Services.AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.AppServices.Interactors
{
    public class StudentInteractor : IStudentInteractor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentInteractor(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Student?>> AddStudent(AddStudentDto Dto)
        {
            try
            {
                var student = _mapper.Map<Student>(Dto);
                var added = await _unitOfWork.StudentRepository.AddAsync(student);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<Student?> { 
                    Success = true,
                    Data = added 
                };
                
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse<IEnumerable<Student>?>> GetStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetAsync();
            return new ApiResponse<IEnumerable<Student>?>
            {
                Success = true,
                Data = students
            }; 
        }
    }
}
