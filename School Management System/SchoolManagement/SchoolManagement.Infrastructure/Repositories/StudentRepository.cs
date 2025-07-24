using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interafces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : EfRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentManagementContext studentManagementContext)
            :base(studentManagementContext) {}

        public Task<Student> GetByIdWithCoursesAsync(int id)
        {
            return _StudentManagementContext.Students
                  .Include(t => t.Courses)
                  .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
