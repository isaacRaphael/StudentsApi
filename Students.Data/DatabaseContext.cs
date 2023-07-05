using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
            {
                // Set primary key
                entity.HasKey(s => s.Id);

                // Set required properties
                entity.Property(s => s.NationalId).IsRequired();
                entity.Property(s => s.Name).IsRequired();
                entity.Property(s => s.Surname).IsRequired();
                entity.Property(s => s.StudentNumber).IsRequired();
                entity.Property(s => s.DateOfBirth)
                    .IsRequired();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                // Set primary key
                entity.HasKey(t => t.Id);

                // Set required properties
                entity.Property(t => t.NationalId).IsRequired();
                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.Surname).IsRequired();
                entity.Property(t => t.TeacherNumber).IsRequired();
                entity.Property(t => t.Title)
                    .IsRequired();
                entity.Property(t => t.DateOfBirth)
                    .IsRequired();

                entity.Property(t => t.Salary).HasColumnType("decimal(18,2)");

            });
            }

    }
}
