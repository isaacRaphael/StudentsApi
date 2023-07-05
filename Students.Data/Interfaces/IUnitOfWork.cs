using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public ITeacherRepository TeacherRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }

        Task<int> CompleteAsync();
    }
}
