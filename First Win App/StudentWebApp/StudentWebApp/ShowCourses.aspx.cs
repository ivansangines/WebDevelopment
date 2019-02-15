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
    public partial class CourseEnrollment : System.Web.UI.Page
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
                        DropDownSemesters.DataSource = SList;
                        DropDownSemesters.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }
            }

        }

        protected void DropDownSemesters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semester = DropDownSemesters.SelectedItem.Text;
            if (semester.IndexOf("DataRowView") < 0)
            {
                try
                {
                    List<CourseOfferedVM> CList = ibCourses.GetCoursesOffered(semester);
                    dgCourses.DataSource = CList;
                    dgCourses.DataBind();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.Message;
                }
            }
        }
    }
}