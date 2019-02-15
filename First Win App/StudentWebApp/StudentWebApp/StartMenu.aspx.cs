using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebApp
{
    public partial class StartMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGGEDIN"] == null)
                Response.Redirect("Login");
            
            

        }

        protected void btnCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowCourses.aspx");
        }

        protected void btnEnrollment_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseEnrollment.aspx");
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForCourses.aspx");
        }

        protected void btnInstructors_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowInstructors.aspx");
        }
    }
}