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
    public class TeacherInteractor : ITeacherInteractor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherInteractor(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<Teacher?>> AddTeacher(AddTeacherDto Dto)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(Dto);
                var added = await _unitOfWork.TeacherRepository.AddAsync(teacher);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<Teacher?>
                {
                    Success = true,
                    Data = added
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse<IEnumerable<Teacher>?>> GetTeachers()
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAsync();
            return new ApiResponse<IEnumerable<Teacher>?>
            {
                Success = true,
                Data = teachers
            };
        }
    }
}
