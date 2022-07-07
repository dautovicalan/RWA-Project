﻿using DataAccessLayer.Dal;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_project
{
    public partial class AddTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormIsValid())
                {
                    return;
                }
                ((IRepo)Application["database"]).CreateTag(new Tag
                {
                    Guid = Guid.NewGuid(),
                    Name = TagName.Text,
                    CreatedAt = DateTime.Now,
                    TypeId = 1,
                    NameEng = TagEnglishName.Text,
                });

                    Response.Redirect("Tags.aspx");
                }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                Response.Redirect("Default.aspx");
            }
        }

        private bool FormIsValid()
        {
            return !String.IsNullOrEmpty(TagName.Text) || !String.IsNullOrEmpty(TagEnglishName.Text);
        }
    }
}