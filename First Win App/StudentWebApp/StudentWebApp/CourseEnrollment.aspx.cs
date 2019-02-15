using System;
using System.Collections.Generic;
using StudentWebApp.Models;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentWebApp.BusinessLayer;

namespace StudentWebApp
{
    public partial class CourseEnrollment1 : System.Web.UI.Page
    {
        //BusinessLayer.BusinessCourses bCourses = new BusinessLayer.BusinessCourses();

        IBusinessCourses ibCourses = new BusinessCourses();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGGEDIN"] == null)
                Response.Redirect("Login");
            else
            {
                try
                {
                    if (!IsPostBack)
                    {
                        List<string> SList = ibCourses.GetSemesters();
                        semesterOptions.DataSource = SList;
                        semesterOptions.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }
            }

        }

        protected void semesterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice = semesterOptions.Text;
            if (choice.IndexOf("DataRowView") < 0)
            {
                try
                {
                    List<string> CList = ibCourses.GetCoursesOfferedForASemester(choice);
                    coursesList.DataSource = CList;
                    coursesList.DataBind();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }
            }
        }

        protected void coursesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semester = semesterOptions.Text;
            string course = coursesList.Text;
            if (course.IndexOf("DataRowView") < 0)
            {
                try
                {
                    List<CourseEnrollmentVM> CList = ibCourses.GetCourseEnrollment(semester, course);
                    gv1.DataSource = CList;
                    gv1.DataBind();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }
            }

        }
    }
}