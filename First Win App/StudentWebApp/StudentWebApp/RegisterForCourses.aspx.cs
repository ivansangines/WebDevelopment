using StudentWebApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebApp
{
    public partial class RegisterForCourses : System.Web.UI.Page
    {
        //BusinessLayer.BusinessCourses _busCourses = new BusinessLayer.BusinessCourses();
        //BusinessLayer.BusinessStudents _busStudents = new BusinessLayer.BusinessStudents();

        IBusinessCourses ibCourses = new BusinessCourses();
        IBusinessStudents ibStudents = new BusinessStudents();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGGEDIN"] == null)
                Response.Redirect("Login");
            else
            {
                if (!IsPostBack)
                {
                    try
                    {
                        List<string> SemesterList = ibCourses.GetSemesters();
                        ddSemester.DataSource = SemesterList;
                        ddSemester.DataBind();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = ex.Message;
                    }
                }
            }

        }

        protected void ddSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            //We need to populate the courses drop down with the semester selected
            string semester = ddSemester.Text;
            if (semester.IndexOf("DataRowView") < 0)
            {
                try
                {
                    List<string> CoursesList = ibCourses.GetCoursesOfferedForASemester(semester);
                    ddCourse.DataSource = CoursesList;
                    ddCourse.DataBind();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string semester = ddSemester.Text;
            string course = ddCourse.Text;
            try
            {
                bool accepted = ibStudents.RegisterStudent(long.Parse(txtStudentID.Text), semester, course);
                if (accepted == true)
                    lblStatus.Text = "Student registered in " + course;
                else
                    lblStatus.Text = "Registration Failed...";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
}