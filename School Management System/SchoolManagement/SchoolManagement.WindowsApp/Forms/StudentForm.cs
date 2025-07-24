using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interafces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.WindowsApp.Forms
{
    public partial class StudentForm : Form
    {
        private readonly IStudentService _studentService;

        public StudentForm(IStudentService studentService)
        {
            _studentService = studentService;
            InitializeComponent();
        }

        private async Task RefreshDataGridViewAsync()
        {
            IReadOnlyList<Student> students = await _studentService.GetStudents();
            dgvStudent.DataSource = students;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Student student = new Student(txbNumber.Text, txbFirstName.Text, txbLastName.Text);
            _studentService.AddStudent(student);
            RefreshDataGridViewAsync();
        }

        private void btnLaodStudents_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewAsync();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dgvStudent.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvStudent.Rows[selectedrowindex];
            int studentId = Convert.ToInt32(selectedRow.Cells["Id"].Value); 
            CourseForm courseForm = new CourseForm(studentId, _studentService);
            courseForm.ShowDialog();
        }
    }
}
