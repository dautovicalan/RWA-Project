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

        public List<Tag> MyTags { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IRepo testing = RepoFactory.GetRepo();
            MyTags = testing.GetTags().ToList();
        }

        protected void AddNewTagButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTag.aspx");
            //IRepo repimir = RepoFactory.GetRepo();
            //repimir.CreateTag(new Tag
            //{
            //    Guid = Guid.NewGuid(),
            //    Name = "Test",
            //    CreatedAt = DateTime.Now,
            //    TypeId = 1,
            //    NameEng = "Test"
            //});
            //RefreshData();
        }

        private void RefreshData() => MyTags = RepoFactory.GetRepo().GetTags().ToList();
    }
}