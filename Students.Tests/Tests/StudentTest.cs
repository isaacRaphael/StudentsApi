using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Tests.Tests
{
    public class StudentTest : TestBase
    {
        [Fact]
        public async Task AddStudent_ThrowsNullabilityErrorException_WhenRequiredFieldsAreNull()
        {
            // Arrange
            var student = new Student(); // Required fields are not set
            await _studentRepoasitory.AddAsync(student);

            // Act and Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () => await _context.SaveChangesAsync());
        }

        [Fact]
        public async Task AddToStudents()
        {
            //Act            
            var added = await  _studentRepoasitory.AddAsync(student);
            await _context.SaveChangesAsync();

            //Assert
            Assert.True(_context.Students.Count() > 0);
        }

        [Fact]
        public async Task GetStudents()
        {
            // Arrange
            var student1 = new Student
            {
                Id = Guid.NewGuid(),
                DateOfBirth = DateTime.Parse("2004-10-03"),
                StudentNumber = "1122334455",
                Surname = "Doe",
                Name = "John",
                NationalId = "13217463258745"
            };
            var student2 = new Student
            {
                Id = Guid.NewGuid(),
                DateOfBirth = DateTime.Parse("2005-11-13"),
                StudentNumber = "0022334411",
                Surname = "Kelly",
                Name = "Jane",
                NationalId = "74526385258754"
            };
            await _studentRepoasitory.AddAsync(student1);
            await _studentRepoasitory.AddAsync(student2);
            await _context.SaveChangesAsync();

            // Act
            var students = await _studentRepoasitory.GetAsync();

            // Assert
            Assert.True(students.Any(x => x.Id == student1.Id));
            Assert.True(students.Any(x => x.Id == student2.Id));
        }

        [Fact]
        public async Task GetStudentById()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                DateOfBirth = DateTime.Parse("2005-11-13"),
                StudentNumber = "4983265987432",
                Surname = "Clark",
                Name = "Kent",
                NationalId = "7439286532948"
            }; ;
            await _studentRepoasitory.AddAsync(student);
            await _context.SaveChangesAsync();

            // Act
            var retrievedStudent = await _studentRepoasitory.GetByIdAsync(student.Id);

            // Assert
            Assert.NotNull(retrievedStudent);
            Assert.Equal(student, retrievedStudent);
        }


    }
}
