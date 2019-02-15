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
    public partial class Form1 : Form
    {
        FormCoursesOffered frmCoursesOffered = null;
        FormCourseEnrollment frmCourseEnrollment = null;
        FormRegisterForCourse frmRegisterForACourse = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowCoursesOffered_Click(object sender, EventArgs e)
        {
            if (frmCoursesOffered == null)
            {
                frmCoursesOffered = new FormCoursesOffered();
                frmCoursesOffered.Show();  // modeless display
            }
            else
            {
                if (frmCoursesOffered.IsDisposed)
                {
                    frmCoursesOffered = new FormCoursesOffered();
                    frmCoursesOffered.Show();  // modeless display
                }
                else
                    frmCoursesOffered.WindowState = FormWindowState.Normal;
            }
        }

        private void btnShowCourseEnrollment_Click(object sender, EventArgs e)
        {
            if (frmCourseEnrollment == null)
            {
                frmCourseEnrollment = new FormCourseEnrollment();
                frmCourseEnrollment.Show();  // modeless display
            }
            else
            {
                if (frmCourseEnrollment.IsDisposed)
                {
                    frmCourseEnrollment = new FormCourseEnrollment();
                    frmCourseEnrollment.Show();  // modeless display
                }
                else
                    frmCourseEnrollment.WindowState = FormWindowState.Normal;
            }
        }

        private void btnShowRegisterForACourse_Click(object sender, EventArgs e)
        {
            if (frmRegisterForACourse == null)
            {
                frmRegisterForACourse = new FormRegisterForCourse();
                frmRegisterForACourse.Show();  // modeless display
            }
            else
            {
                if (frmRegisterForACourse.IsDisposed)
                {
                    frmRegisterForACourse = new FormRegisterForCourse();
                    frmRegisterForACourse.Show();  // modeless display
                }
                else
                    frmRegisterForACourse.WindowState = FormWindowState.Normal;
            }
        }
    }
}
