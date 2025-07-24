using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interafces;
using SchoolManagement.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAsyncRepository<Course> _courseRepository;


        public StudentService(IStudentRepository studentRepository, IAsyncRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _studentRepository.GetByIdWithCoursesAsync(id);
        }

        public Task<IReadOnlyList<Student>> GetStudents()
        {
            return _studentRepository.ListAllAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task AddStudent(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task DeleteStudent(Student student)
        {
            await _studentRepository.DeleteAsync(student);
        }

        public async Task AddCourse(int studentId, Course course)
        {
            Student student = await _studentRepository.GetByIdAsync(studentId);
            if(student != null)
            {
                student.AddCourse(course);
                await _studentRepository.UpdateAsync(student);
            }
        }
    }
}
