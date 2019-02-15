using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentWinApp
{
    public partial class FormRegisterForCourse : Form
    {
        BusinessLayer.BusinessCourses _busCourses = new BusinessLayer.BusinessCourses();
        BusinessLayer.BusinessStudents _busStudents = new BusinessLayer.BusinessStudents();
        public FormRegisterForCourse()
        {
            InitializeComponent();
        }

        private void FormRegisterForCourse_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> SList = _busCourses.GetSemesters();
                cmbSemesters.DataSource = SList;
                cmbSemesters.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSemesters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semester = cmbSemesters.Text;
            if (semester.IndexOf("DataRowView") < 0)
            {
                try
                {
                    // populate the cmbCoursesOffered with the courses being offered for the selected semester
                    List<string> CList = _busCourses.GetCoursesOfferedForASemester(semester);
                    cmbCoursesOffered.DataSource = CList;
                    cmbCoursesOffered.Refresh();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRegisterForCourse_Click(object sender, EventArgs e)
        {
            string semester = cmbSemesters.Text;
            string courseNum = cmbCoursesOffered.Text;
            try
            {
                bool ret = _busStudents.RegisterStudent(long.Parse(txtStudentId.Text), semester, courseNum);
                if (ret == true)
                    MessageBox.Show("Student registered successfully in " + courseNum);
                else
                    MessageBox.Show("Problem in registratio..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
