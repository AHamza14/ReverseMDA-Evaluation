using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interafces
{
    public interface IStudentService
    {
        public Task<IReadOnlyList<Student>> GetStudents();
        public Task<Student> GetStudent(int id);
        public Task AddStudent(Student student);
        public Task UpdateStudent(Student student);
        public Task DeleteStudent(Student student);
        public Task AddCourse(int studentId, Course course);
    }
}
