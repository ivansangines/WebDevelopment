using StudentWebApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                IBusinessAuthentication iba = new BusinessAuthentication();
                bool ret = iba.VerifyLogin(txtUser.Text, txtPassword.Text);
                if (ret == true)
                {
                    Session["LOGGEDIN"] = true;
                    Response.Redirect("StartMenu");
                }
                else
                    if(IsPostBack)
                        lblStatus.Text = "Invalid Login";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

    
    }
}