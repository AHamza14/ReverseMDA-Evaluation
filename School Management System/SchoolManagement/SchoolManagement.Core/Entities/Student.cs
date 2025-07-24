using SchoolManagement.SharedKernel;
using SchoolManagement.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Core.Entities
{
    public class Student : BaseEntity, IAggregateRoot
    {
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public Student()
        {

        }

        public Student(string number, string firstName, string lastName)
        {
            this.Number = number;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            Courses.Remove(course);
        }
    }
}
