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
    public partial class Tags : System.Web.UI.Page
    {

        public List<Tag> MyTags { get; set; }
        protected void Page_Load(object sender, EventArgs e)
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
    }
}