using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Students.Data;
using Students.Data.Interfaces;
using Students.Data.Repositories;
using Students.Domain.DTOs.Requests;
using Students.Domain.DTOs.Responses;
using Students.Domain.Entities;
using Students.Services.AppServices.Interactors;
using Students.Services.AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Tests.Tests
{
    public class TestBase
    {

        protected readonly IStudentRepository _studentRepoasitory;
        protected readonly ITeacherRepository _teacherRepository;

        protected Student student;
        protected AddStudentDto studentDto;
        protected Teacher teacher;

        protected DbContextOptions<DatabaseContext> _contextOptions;
        protected DatabaseContext _context;
        protected readonly Mock<IUnitOfWork> _unitOfWork;

        protected List<Student> studentsSet = new List<Student>();
        protected List<Teacher> teachersSet = new List<Teacher>();
        
        public TestBase()
        {
            _contextOptions = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "StudentsApiDataBase").Options;
            _unitOfWork= new Mock<IUnitOfWork>();
            var _mapper = new Mock<IMapper>();

            student = new Student
            {
                Id = Guid.NewGuid(),    
                DateOfBirth = DateTime.Parse("2004-10-03"),
                StudentNumber = "1122334455",
                Surname = "Doe",
                Name = "John",
                NationalId = "13217463258745"
            };

            _context = new DatabaseContext(_contextOptions);
            _studentRepoasitory = new StudentRepository(_context);
            _teacherRepository = new TeacherRepository(_context);

            _unitOfWork.Setup(x => x.StudentRepository.GetByIdAsync(student.Id)).ReturnsAsync(student);
            _unitOfWork.Setup(x => x.StudentRepository.AddAsync(It.IsAny<Student>()))
                .Callback((Student student) => studentsSet.Add(student));
        }
    }
}
