using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interafces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.WindowsApp.Forms
{
    public partial class CourseForm : Form
    {
        private readonly IStudentService _studentService;
        private int _studentId;

        public CourseForm(int studentId, IStudentService studentService)
        {
            _studentService = studentService;
            _studentId = studentId;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Course course = new Course(txbNumber.Text, txbBalance.Text);
            _studentService.AddCourse(_studentId, course);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewAsync();
        }

        private async Task RefreshDataGridViewAsync()
        {
            Student student = await _studentService.GetStudent(_studentId);
            dgvCourse.DataSource = student.Courses;
        }
    }
}
