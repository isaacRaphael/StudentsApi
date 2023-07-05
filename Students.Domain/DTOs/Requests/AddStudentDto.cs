using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.DTOs.Requests
{
    //Validation is handled by Fluent Validation
    public class AddStudentDto
    {
        public string? NationalId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? StudentNumber { get; set; }
    }
}
