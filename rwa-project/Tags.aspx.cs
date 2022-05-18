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
    public partial class Tags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            FillDataInRepeater();
        }

        private void FillDataInRepeater()
        {
            Repeater1.DataSource = ((IRepo)Application["database"]).GetTags();
            Repeater1.DataBind();
        }

        protected void AddNewTagButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTag.aspx");
        }

        public bool ShowDeleteButton(string msg)
        {
            return int.Parse(msg) == 0;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                pnlModal.Visible = true;
                Session["selectedIdForDeleting"] = int.Parse(e.CommandArgument.ToString());
            }
        }

        protected void btnDeleteCancel_Click(object sender, EventArgs e)
        {
            pnlModal.Visible=false;
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (Session["selectedIdForDeleting"] == null)
            {
                pnlModal.Visible = false;
                return;
            }
            ((IRepo)Application["database"]).DeleteTagById((int)Session["selectedIdForDeleting"]);
            pnlModal.Visible = false;
            FillDataInRepeater();
        }
    }
}