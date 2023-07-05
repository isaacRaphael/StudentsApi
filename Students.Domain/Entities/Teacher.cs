using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string? NationalId { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string?  Surname { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public string?  TeacherNumber { get; set; }
        public decimal  Salary { get; set; }
    }
}
