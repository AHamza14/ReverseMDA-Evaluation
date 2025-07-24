using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Core.Specifications
{
    public class CourseByTitle : BaseSpecification<Course>
    {
        public CourseByTitle(string courseTitle) : base(x => x.Title == courseTitle)
        {
        }
    }

}
