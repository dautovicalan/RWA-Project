using DataAccessLayer.Dal;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_project
{
    public partial class RegisterUsers : System.Web.UI.Page
    {
        public List<AspNetUser> ListOfUsers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                ListOfUsers = new List<AspNetUser>();
                ((IRepo)Application["database"]).GetAspNetUsers().ToList().ForEach(a => ListOfUsers.Add(a));
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                Response.Redirect("Default.aspx");
            }
        }
    }
}