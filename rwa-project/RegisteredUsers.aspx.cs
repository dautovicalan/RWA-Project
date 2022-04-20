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
            ListOfUsers = new List<AspNetUser>();
            RepoFactory.GetRepo().GetAspNetUsers().ToList().ForEach(a => ListOfUsers.Add(a));
        }
    }
}