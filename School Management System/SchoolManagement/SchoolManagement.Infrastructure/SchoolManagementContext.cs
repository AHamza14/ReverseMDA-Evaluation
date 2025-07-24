using SchoolManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Infrastructure
{
    public class StudentManagementContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StudentManagementContext(DbContextOptions options) : base(options) { }

        public StudentManagementContext() : base(new DbContextOptionsBuilder<StudentManagementContext>()
                    .UseSqlServer(@"Server=.;Database=StudentManagementDB;Trusted_Connection=True;")
                    .Options)
        { }
    }
}
