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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            IRepo repo = RepoFactory.GetRepo();
            IList<Apartment> apartmens = repo.GetApartments();

            string init = "";
            apartmens.ToList().ForEach(apartm => init += apartm.Guid.ToString());

            lblTest.Text = init;
        }
    }
}