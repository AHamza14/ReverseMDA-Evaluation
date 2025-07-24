using SchoolManagement.SharedKernel;
using SchoolManagement.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Core.Entities
{
    public class Course: BaseEntity, IAggregateRoot
    {
        public Course()
        {

        }
        public Course(string title, int credit)
        {
            Title = title;
            Credit = credit;
        }

        public string Title { get; set; }
        public int Credit { get; set; }
    }
}
