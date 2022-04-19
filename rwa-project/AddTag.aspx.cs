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
    public partial class AddTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!FormIsValid())
            {
                return;
            }
            IRepo repimir = RepoFactory.GetRepo();

            repimir.CreateTag(new Tag
            {
                Guid = Guid.NewGuid(),
                Name = TagName.Text,
                CreatedAt = DateTime.Now,
                TypeId = 1,
                NameEng = TagEnglishName.Text,
            });

            Response.Redirect("Tags.aspx");
        }

        private bool FormIsValid()
        {
            return !String.IsNullOrEmpty(TagName.Text) || !String.IsNullOrEmpty(TagEnglishName.Text);
        }
    }
}