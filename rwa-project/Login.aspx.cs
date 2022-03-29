using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("Default.aspx");
            this.PanelError.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (!IsUserValidated(txtUserName.Text, txtPassword.Text))
            {
                this.PanelError.Visible=true;
                return;
            }
            this.PanelError.Visible=false;
            Session["user"] = txtUserName.Text;
            Response.Redirect("Default.aspx");                        
        }

        private bool IsUserValidated(string username, string password) => username == "admin" && password == "123" ? true : false;        
    }
}