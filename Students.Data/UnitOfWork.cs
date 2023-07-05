using Students.Data.Interfaces;
using Students.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            TeacherRepository = new TeacherRepository(context);
            StudentRepository= new StudentRepository(context);
            _context = context;
        }
        public ITeacherRepository TeacherRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null) 
                {
                    _context.Dispose(); 
                }
            }
        }
    }
}
