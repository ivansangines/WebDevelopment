using StudentWebApp.DataLayer;
using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebApp
{
    public partial class ShowInstructors : System.Web.UI.Page
    {
        IRepositoryInstructors irep = new RepositoryInstructors();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGGEDIN"] == null)
                Response.Redirect("Login");
            else
            {
                try
                {
                    List<Instructors> CList = irep.GetInstructors();
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