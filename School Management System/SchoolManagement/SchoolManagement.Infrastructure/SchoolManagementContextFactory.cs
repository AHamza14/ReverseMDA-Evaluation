using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Infrastructure
{
    public class StudentManagementContextFactory : IDesignTimeDbContextFactory<StudentManagementContext>

    {
        public StudentManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=StudentManagementDB;Trusted_Connection=True;");
            return new StudentManagementContext(optionsBuilder.Options);
        }

    }
}
