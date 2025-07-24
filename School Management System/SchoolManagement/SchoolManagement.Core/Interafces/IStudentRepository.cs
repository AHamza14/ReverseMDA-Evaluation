using SchoolManagement.Core.Entities;
using SchoolManagement.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interafces
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<Student> GetByIdWithCoursesAsync(int id);
    }
}
