using Microsoft.EntityFrameworkCore;
using Students.Data.Repositories;
using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Tests.Tests
{
    public class TeacherTest : TestBase
    {

        public TeacherTest()
        {

             
        }
        [Fact]
        public async Task AddTeacher_ThrowsNullabilityErrorException_WhenRequiredFieldsAreNull()
        {
            // Arrange
            var teacher = new Teacher(); // Required fields are not set

            // Act and Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () => {
                await _teacherRepository.AddAsync(teacher);
                await _context.SaveChangesAsync();
            });
        }

        [Fact]
        public async Task AddToTeachers()
        {
            // Arrange
            var teacher = new Teacher
            {
                NationalId = "12345678",
                Name = "John",
                Surname = "Doe",
                TeacherNumber = "45436545675",
                Title = "Mr",
                DateOfBirth = DateTime.Parse("1980-01-01"),
                Salary = 50000.0m
            };

            // Act            
            var added = await _teacherRepository.AddAsync(teacher);
            await _context.SaveChangesAsync();

            // Assert
            Assert.True(_context.Teachers.Count() > 0);
        }

        [Fact]
        public async Task GetTeachers()
        {
            // Arrange
            var teacher1 = new Teacher
            {
                Id = Guid.NewGuid(),
                NationalId = "12345678",
                Name = "John",
                Surname = "Doe",
                TeacherNumber = "9832657435",
                Title = "Mr",
                DateOfBirth = DateTime.Parse("1980-01-01"),
                Salary = 50000.0m
            };
            var teacher2 = new Teacher
            {
                Id = Guid.NewGuid(),
                NationalId = "87654321",
                Name = "Jane",
                Surname = "Kelly",
                TeacherNumber = "328746538745",
                Title = "Mrs",
                DateOfBirth = DateTime.Parse("1985-05-05"),
                Salary = 60000.0m
            };
            await _teacherRepository.AddAsync(teacher1);
            await _teacherRepository.AddAsync(teacher2);
            await _context.SaveChangesAsync();

            // Act
            var teachers = await _teacherRepository.GetAsync();

            // Assert
            Assert.True(teachers.Any(x => x.Id == teacher1.Id));
            Assert.True(teachers.Any(x => x.Id == teacher2.Id));
        }

        [Fact]
        public async Task GetTeacherById()
        {
            // Arrange
            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                NationalId = "12345678",
                TeacherNumber = "63482165745",
                Title= "Mr",
                Name = "John",
                Surname = "Doe",
                DateOfBirth = DateTime.Parse("1980-01-01"),
                Salary = 50000.0m
            };
            await _teacherRepository.AddAsync(teacher);
            await _context.SaveChangesAsync();

            // Act
            var retrievedTeacher = await _teacherRepository.GetByIdAsync(teacher.Id);

            // Assert
            Assert.NotNull(retrievedTeacher);
            Assert.Equal(teacher, retrievedTeacher);
        }
    }
}
