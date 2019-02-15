using StudentWinApp.Models;
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
    public partial class FormCoursesOffered : Form
    {
        BusinessLayer.BusinessCourses _busCourses = new BusinessLayer.BusinessCourses();
        public FormCoursesOffered()
        {
            InitializeComponent();
        }

        private void FormCoursesOffered_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> SList = _busCourses.GetSemesters();
                // databinding : assign the datasource and call refresh
                cmbSemesters.DataSource = SList;
                cmbSemesters.Refresh();
            }
            catch (Exception ex)
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
                    List<CourseOfferedVM> CList = _busCourses.GetCoursesOffered(semester);
                    dgCoursesOffered.DataSource = CList;
                    dgCoursesOffered.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
